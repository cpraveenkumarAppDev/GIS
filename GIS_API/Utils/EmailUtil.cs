using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace GIS_API.Utils
{
    public class EmailUtil
    {
        internal static void Message(MailMessage message)
        {
            SmtpClient smtp = new SmtpClient
            {
                EnableSsl = false
            };
            smtp.Send(message);
        }
    }
}