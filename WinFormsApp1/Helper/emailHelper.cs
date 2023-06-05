using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using WinFormsApp1.Helper.email;
using System.Drawing.Imaging;

namespace WinFormsApp1.Helper
{
    public class emailHelper
    {
        public static void sendEmail(String to)
        {

           // string imageBase64 = ConvertBitmapToBase64(globalVariables.idPic);
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("CrewConnect.automated@gmail.com");
                msg.To.Add(to);
                msg.Subject = "CREW CONNECT EMPLOYEE DETAILS";
                // Create the HTML view
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                    htmlHelper.emailTemplate_Register(
                    globalVariables.username,
                    "asd"), 
                    null, "text/html");
                msg.AlternateViews.Add(htmlView);
                msg.Attachments.Add(new Attachment("..\\..\\..\\Helper\\email\\images\\id.png"));
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("CrewConnect.automated@gmail.com", "onoqebflyqryxgys");
                smtp.EnableSsl = true;

                smtp.Send(msg);
                msg.Dispose();
                smtp.Dispose();
                MessageBox.Show("Your Email Has Been Sent!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void sendEmail(String to, bool isDebug)
        {

            // string imageBase64 = ConvertBitmapToBase64(globalVariables.idPic);
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("CrewConnect.automated@gmail.com");
                msg.To.Add(to);
                msg.Subject = "CREW CONNECT EMPLOYEE DETAILS";
                // Create the HTML view
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                    htmlHelper.emailTemplate_Register(
                    "SANTOS_YGI_TESTING_PURPOSES",
                    "asd"),
                    null, "text/html");
                msg.Attachments.Add(new Attachment("..\\..\\..\\Helper\\email\\images\\id.png"));
                msg.AlternateViews.Add(htmlView);

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("CrewConnect.automated@gmail.com", "onoqebflyqryxgys");
                smtp.EnableSsl = true;

                smtp.Send(msg);
                msg.Dispose();
                smtp.Dispose();

                messageDialogForm dia = new messageDialogForm();
                dia.isOkDialog = false;
                dia.message = "Your Email Has Been Sent!";
                dia.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
}
