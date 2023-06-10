using AForge.Video;
using AForge.Video.DirectShow;
using Guna.UI2.WinForms;
using System.Drawing.Imaging;
using System.Drawing;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using Microsoft.Data.SqlClient;
using System.Data;

namespace WinFormsApp1.Helper
{
    public class cameraHelper
    {
        private static FilterInfoCollection videoDevices; // Stores available video devices
        private static VideoCaptureDevice videoSource; // Represents the video capture device
        private static bool capturing = false; // Indicates if we are currently capturing
        private static QRCodeReader barcodeReader;
        private static Bitmap frame;

        public static bool isValid = false;
        public static string fullName, idNum, dateString, timeString;
        public static void closeForm()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
                videoSource = null;
            }
        }

        public static void changeCam(int index)
        {
            if (capturing)
            {
                closeForm();
            }

            videoSource = new VideoCaptureDevice(videoDevices[index].MonikerString);

            videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame); // Event handler for new frames

            videoSource.Start(); // Start capturing
            capturing = true;
        }
        private static void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (!capturing) return;

            frame = (Bitmap)eventArgs.Frame.Clone(); // Clone the new frame to avoid cross-threading issues

            if(qrcode)
            {
                barcodeReader = new QRCodeReader();
                // Convert the Bitmap to a byte array
                byte[] byteArray = BitmapToByteArray(frame);

                // Convert the Bitmap to ZXing's RGBLuminanceSource
                RGBLuminanceSource luminanceSource = new RGBLuminanceSource(byteArray, frame.Width, frame.Height);

                // Create a BinaryBitmap from the luminance source
                BinaryBitmap binaryBitmap = new BinaryBitmap(new HybridBinarizer(luminanceSource));


                // Read QR code from the frame
                Result result = barcodeReader.decode(binaryBitmap);

                if (result != null)
                {
                    // Display the decoded QR code value
                    string qrCodeValue = result.Text;
                    DateOnly date_ = DateOnly.FromDateTime(DateTime.Now);
                    TimeOnly time_ = TimeOnly.FromDateTime(DateTime.Now);

                    idNum = qrCodeValue;
                    dateString = date_.ToShortDateString();
                    timeString = time_.ToShortTimeString();
                    fullName = getName(id);
                    isDetect = true;
                    if(name == "home")
                    {
                        attendance.att.setData(idNum, dateString, timeString, fullName);
                    }

                    if (videoSource != null && videoSource.IsRunning)
                    {
                        videoSource.SignalToStop();
                        videoSource.WaitForStop();
                    }
                }
            }
            frame = CropToSquare(frame);
            selfPic.Image = frame; // Display the frame on the PictureBox
        }


        public static void onLoad()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice); // Get available video devices

            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No video devices found.");
                return;
            }

            foreach (FilterInfo device in videoDevices)
            {
                camListCB.Items.Add(device.Name); // Add the device name to the ComboBox
            }

            camListCB.SelectedIndex = 0; // Select the first device by default
            changeCam(0);
        }

        public static void captureBtn()
        {
            globalVariables.selfPic = frame;
        }
        public static void start(int i)
        {
            videoSource = null;
            changeCam(i);
        }
        private static byte[] BitmapToByteArray(Bitmap bitmap)
        {
            using (var stream = new System.IO.MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                return stream.ToArray();
            }
        }
        private static Bitmap CropToSquare(Bitmap image)
        {
            int size = Math.Min(image.Width, image.Height);

            int x = (image.Width - size) / 2;
            int y = (image.Height - size) / 2;

            Rectangle cropArea = new Rectangle(x, y, size, size);

            Bitmap squareImage = image.Clone(cropArea, image.PixelFormat);

            return squareImage;
        }

        static string getName(string id)
        {
            try
            {
                string query = $"SELECT name FROM personal WHERE Id = '{idNum}';";
                using (SqlConnection con = new SqlConnection(globalVariables.server))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            isValid = true;
                            return dr.GetString(0);
                        }
                        else
                        {
                            isValid = false;
                            messageDialogForm msg = new messageDialogForm();
                            msg.isOkDialog = false;
                            msg.title = "";
                            msg.message = $"The {idNum} Employee Number Does not Exist";
                            msg.StartPosition = FormStartPosition.CenterScreen;
                            msg.ShowDialog();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                messageDialogForm msg = new messageDialogForm();
                msg.title = "AN ERROR HAS OCCURED";
                msg.message = ex.Message;
                msg.ShowDialog();
            }
            return "";
        }
        public static Guna2ComboBox camListCB { get; set; }
        public static Guna2PictureBox selfPic { get; set; }
        public static bool qrcode { get; set; }
        public static string id { get; set; }
        public static string name { get; set; }
        public static bool isDetect { get; set; }
    }
}
