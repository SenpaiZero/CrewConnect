using QRCoder;


namespace CrewConnect.Helper
{
    internal class qrCodeHelper
    {

        // Generating qr code based on qrcode library
       public static Bitmap generateQrCode(string idNum)
        {
            using QRCodeGenerator generator = new QRCodeGenerator();
            using QRCodeData data = generator.CreateQrCode(idNum, QRCodeGenerator.ECCLevel.Q);
            using QRCode qrCode = new QRCode(data);

            return qrCode.GetGraphic(
                20, // Pixel per module
                Color.Black, 
                Color.White,
                new Bitmap(Properties.Resources.logo)
                );
        }
    }
}
