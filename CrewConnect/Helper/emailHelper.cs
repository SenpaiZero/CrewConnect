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
                    globalVariables.usernameNew,
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

        public static void sendEmail_payslip(String to,
            string contract, string hrs_ot, string workDays,
            string empName, string empPosition, double basicPay, double otPay, double allowance,
            double others, double sss, double pagIbig, double philHealth, double grossPay,
            double deduction, double netPay)
        {

            // string imageBase64 = ConvertBitmapToBase64(globalVariables.idPic);
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("CrewConnect.automated@gmail.com");
                msg.To.Add(to);
                msg.Subject = "CREW CONNECT PAYSLIP";
                // Create the HTML view
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                    htmlHelper.emailTemplate_payslip(contract, hrs_ot, workDays, empName, empPosition,
                    basicPay, otPay, allowance, others, sss, pagIbig, philHealth, grossPay, deduction, netPay),
                    null, "text/html");
                msg.AlternateViews.Add(htmlView);
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("CrewConnect.automated@gmail.com", "onoqebflyqryxgys");
                smtp.EnableSsl = true;

                smtp.Send(msg);
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
    }
    
}
