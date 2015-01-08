using System;
using System.Net.Mail;

namespace PartyInvites.Models
{
    public static class SendEmail
    {
        public static string SendEmails(string name, string attending)
        {
            bool at = Convert.ToBoolean(attending);
            try
            {
                MailMessage m = new MailMessage();
                SmtpClient sc = new SmtpClient();

                m.From = new MailAddress("m.speakman89@googlemail.com");
                m.To.Add("m.speakman89@googlemail.com");
                m.Subject = "RSVP Notification";
                m.IsBodyHtml = true;

                if (at)
                {
                    m.Body = name + " is attending";
                }
                else if (!at)
                {
                    m.Body = name + " is not attending";
                }

                // m.Body = name + " is" + ((attending false) ? "" : " not") + " attending";
                sc.Host = "smtp.gmail.com";
                sc.Port = 587;
                sc.Credentials = new System.Net.NetworkCredential("m.speakman89@googlemail.com", "myPassword");
                sc.EnableSsl = true;
                sc.Send(m);

                return "Email confirmed";
            }
            catch (Exception)
            {
                return "Email unconfirmed";
            }
        }
    }
}
