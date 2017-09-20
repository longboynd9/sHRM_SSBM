using System;
using System.Collections.Generic;
using System.Web;
using System.Text.RegularExpressions;
using System.Linq;
using System.Net;
using Microsoft.Exchange.WebServices.Data;

namespace iHRM.Common.Code
{
    //ducnm from huynq - 22/09/2013
    /// <summary>
    /// Send email from outlook
    /// </summary>
    public class SendMailExchange
    {
        string mail_id, mail_pw;

        public SendMailExchange(string eID, string ePW)
        {
            this.mail_id = eID;
            this.mail_pw = ePW;
        }

        /// <summary>
        /// Send mail
        /// </summary>
        /// <param name="to">tới, cách nhau bởi [;]</param>
        /// <param name="subject">tiêu đề</param>
        /// <param name="body">nội dung</param>
        /// <returns></returns>
        public bool sendMailTo(string to, string subject, string body)
        {
            return sendMailTo(to, "", "", subject, body, "");
        }

        /// <summary>
        /// Send mail
        /// </summary>
        /// <param name="from">từ</param>
        /// <param name="to">tới, cách nhau bởi [;]</param>
        /// <param name="cc">cc="", cách nhau bởi [;]</param>
        /// <param name="bcc">bcc="", cách nhau bởi [;]</param>
        /// <param name="subject">tiêu đề</param>
        /// <param name="body">nội dung</param>
        /// <param name="attachment">đính kèm file="", cách nhau bởi [;]</param>
        /// <returns></returns>
        public bool sendMailTo(string to, string cc, string bcc, string subject, string body, string attachment)
        {
            string from = mail_id;
            if (!IsValidEmail(from))
                throw new Exception("email from not in-vaild (" + from + ")");
            
            try
            {
                ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013);

                service.Credentials = new WebCredentials(from, mail_pw);
                service.TraceEnabled = true;
                service.TraceFlags = TraceFlags.All;
                service.AutodiscoverUrl(from, RedirectionUrlValidationCallback);

                EmailMessage email = new EmailMessage(service);
                email.ToRecipients.AddRange(to.Split(';'));
                email.CcRecipients.AddRange(cc.Split(';'));
                email.BccRecipients.AddRange(bcc.Split(';'));
                email.Subject = subject;
                email.Body = new MessageBody(BodyType.HTML, body);

                email.Send();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidEmail(string email)
        {
            //regular expression pattern for valid email
            //addresses, allows for the following domains:
            //com,edu,info,gov,int,mil,net,org,biz,name,museum,coop,aero,pro,tv
            //string pattern = @"^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$";
            string pattern = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            //Regular expression object
            Regex check = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);
            //boolean variable to return to calling method
            bool valid = false;

            //make sure an email address was provided
            if (string.IsNullOrEmpty(email))
            {
                valid = false;
            }
            else
            {
                //use IsMatch to validate the address
                valid = check.IsMatch(email);
            }
            //return the value to the calling method
            return valid;
        }
        
        private bool RedirectionUrlValidationCallback(string redirectionUrl)
        {
            // The default for the validation callback is to reject the URL.
            bool result = false;

            Uri redirectionUri = new Uri(redirectionUrl);

            // Validate the contents of the redirection URL. In this simple validation
            // callback, the redirection URL is considered valid if it is using HTTPS
            // to encrypt the authentication credentials. 
            if (redirectionUri.Scheme == "https")
            {
                result = true;
            }
            return result;
        }
    }
}