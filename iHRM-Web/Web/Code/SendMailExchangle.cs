using iHRM.WebPC.Business.Logic;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace iHRM.WebPC.Code
{
    public class SendMailExchangle
    {
        public SendMailExchangle()
        {
        }
        public bool sendMailExchangle(string to, string subject, string body)
        {
            try
            {
                ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013);

                service.Credentials = new WebCredentials(AllLogic.SysPa_Get("mail_u"), AllLogic.SysPa_Get("mail_p"));

                service.TraceEnabled = true;
                service.TraceFlags = TraceFlags.All;

                service.AutodiscoverUrl(AllLogic.SysPa_Get("mail_u"), RedirectionUrlValidationCallback);

                EmailMessage email = new EmailMessage(service);
                //  email.From.Address = "hr@smart-shirts.com.vn";
                email.ToRecipients.Add("huyfithou1989@gmail.com");
                addMailAddress(email, to);

                email.Subject = subject;
                email.Body = new MessageBody(body);

                email.Send();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        private static bool RedirectionUrlValidationCallback(string redirectionUrl)
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
        public static bool IsValidDate(string date)
        { //regular expression pattern for valid email
            //addresses, allows for the following domains:
            //com,edu,info,gov,int,mil,net,org,biz,name,museum,coop,aero,pro,tv
            //string pattern = @"^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$";
            string pattern = @"(((0[1-9]|[12][0-9]|3[01])([-./])(0[13578]|10|12)([-./])(\d{4}))|(([0][1-9]|[12][0-9]|30)([-./])(0[469]|11)([-./])(\d{4}))|((0[1-9]|1[0-9]|2[0-8])([-./])(02)([-./])(\d{4}))|((29)(\.|-|\/)(02)([-./])([02468][048]00))|((29)([-./])(02)([-./])([13579][26]00))|((29)([-./])(02)([-./])([0-9][0-9][0][48]))|((29)([-./])(02)([-./])([0-9][0-9][2468][048]))|((29)([-./])(02)([-./])([0-9][0-9][13579][26])))";
            //Regular expression object
            Regex check = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);
            //boolean variable to return to calling method
            bool valid = false;

            //make sure an email address was provided
            if (string.IsNullOrEmpty(date))
            {
                valid = false;
            }
            else
            {
                //use IsMatch to validate the address
                valid = check.IsMatch(date);
            }
            //return the value to the calling method
            return valid;
        }
        private static void addMailAddress(EmailMessage m, string add)
        {
            if (string.IsNullOrEmpty(add)) return;

            if (add.IndexOf(';') > 0)
            {
                string[] tos = add.Split(';');
                foreach (string too in tos)
                    m.ToRecipients.Add(too);
            }
            else
            {
                m.ToRecipients.Add(add);
            }
        }
    }
}