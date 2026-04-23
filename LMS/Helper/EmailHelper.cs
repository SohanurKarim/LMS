using System.Net;
using System.Net.Mail;
namespace EmailSender.Helper
{
    public class EmailHelper
    {
        public bool SendEmail(string to, string subject, string msg)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("sohanur.vu5.cse5@gmail.com");
            message.To.Add(new MailAddress(to));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = msg;
           
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            //Here use app password for gmail account, not the actual password. You can generate app password from your google account security settings.
            smtp.Credentials = new NetworkCredential("sohanur.vu5.cse5@gmail.com", "irxr iatr ehke uggc");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                smtp.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
                return false;
            }
        }
    }
}
