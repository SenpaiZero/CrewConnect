using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using CrewConnect.Helper.email;
using System.Drawing.Imaging;

namespace CrewConnect.Helper
{
    public class emailHelper
    {
        public static void sendEmail(String to)
        {

            string directoryPath = "..\\..\\..\\Helper\\email\\images\\id.png";
            // string imageBase64 = ConvertBitmapToBase64(globalVariables.idPic);
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("CrewConnect.automated@gmail.com");
                msg.To.Add(to);
                msg.Subject = "CREW CONNECT EMPLOYEE DETAILS";

                // Create a LinkedResource for the image file
                LinkedResource linkedImage = new LinkedResource(directoryPath, "image/png");
                linkedImage.ContentId = "embeddedImage";
                linkedImage.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;

                // Create the HTML view
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                    htmlHelper.emailTemplate_Register(
                    globalVariables.usernameNew,
                    "cid:embeddedImage"), 
                    null, "text/html");
                htmlView.LinkedResources.Add(linkedImage);
                msg.AlternateViews.Add(htmlView);
                msg.Attachments.Add(new Attachment(directoryPath));
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("CrewConnect.automated@gmail.com", "onoqebflyqryxgys");
                smtp.EnableSsl = true;

                smtp.Send(msg);

                // Dispose the linkedImage and remove it from the AlternateView to release the file lock
                linkedImage.Dispose();
                htmlView.LinkedResources.Remove(linkedImage);

                msg.Dispose();
                smtp.Dispose();
                messageDialogForm msg1 = new messageDialogForm();
                msg1.title = "Your Email Has Been Sent!";
                msg1.message = "Please check your spam if you did not recieve the email!";
                msg1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void sendEmail_payslip(String to, Bitmap image)
        {

            // Create a new MailMessage object
            // Save the image to a temporary file
            string tempImagePath = Path.GetTempFileName();
            image.Save(tempImagePath, ImageFormat.Png);

            // Create a new MailMessage object
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("CrewConnect.automated@gmail.com");
            mail.To.Add(to);
            mail.Subject = "CREW CONNECT PAYSLIP";
            mail.Body = "Check out the embedded image!";

            // Create a LinkedResource for the image file
            LinkedResource linkedImage = new LinkedResource(tempImagePath, "image/png");
            linkedImage.ContentId = "embeddedImage";
            linkedImage.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;

            // Create an HTML body with the embedded image
            string htmlBody = "<html><body><img src='cid:embeddedImage'></body></html>";

            // Create an AlternateView with the HTML body
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(htmlBody, null, "text/html");
            htmlView.LinkedResources.Add(linkedImage);
            mail.AlternateViews.Add(htmlView);

            // Send the email using SMTP
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("CrewConnect.automated@gmail.com", "onoqebflyqryxgys");
            smtp.EnableSsl = true;
            smtp.Send(mail);

            messageDialogForm msg1 = new messageDialogForm()
            {
                title = "Your Email Has Been Sent!",
                message = "Please check your spam if you did not recieve the email!"
            };

            msg1.ShowDialog();

            // Dispose the linkedImage and remove it from the AlternateView to release the file lock
            linkedImage.Dispose();
            htmlView.LinkedResources.Remove(linkedImage);

            // Delete the temporary image file
            File.Delete(tempImagePath);
        }
    }
    
}
