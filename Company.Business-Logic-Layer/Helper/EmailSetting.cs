using Company.Business_Logic_Layer.Helper;
using System.Net;
using System.Net.Mail;

namespace Company.Busines_Logic_Layer.Helper
{
    public class EmailSetting
    {
        public static void SendEmail(Email input )
        {
         
            var client = new SmtpClient(host: "smtp.gmail.com", port: 587);    // send email
            
            client.Credentials = new System.Net.NetworkCredential("jfijcc124@gmail.com", "aainxxblnxedgxqy");

            client.EnableSsl = true;

            client.Credentials = new NetworkCredential("LeindaDemy@gmail.com", "aainxxblnxedgxqy");

            client.Send("leindademy@gmail.com", input.To, input.Subject, input.Body);
        }
    }
}
