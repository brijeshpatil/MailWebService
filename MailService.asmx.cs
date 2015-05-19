using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Services;

namespace MailWebService
{
    /// <summary>
    /// Summary description for MailService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MailService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string SendMail(string SenderEmailID, string SenderPassword, string ReceiverEmailID, string Subject, string MailBody)
        {

            MailMessage mail = new MailMessage();
            mail.To.Add(ReceiverEmailID);
            mail.From = new MailAddress(SenderEmailID);
            mail.Subject = Subject;
            mail.Body = MailBody;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(SenderEmailID, SenderPassword);
            smtp.EnableSsl = true;
            string IsSent = "";
            try
            {
                smtp.Send(mail);
                IsSent = "Mail Sent Successfully";
            }
            catch (Exception e)
            {
                IsSent = e.Message;
            }


            return IsSent;
        }

    }
}
