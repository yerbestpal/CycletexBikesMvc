// name: Ross McLean
// date: 16/05/20

using System;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace CycletexBikesMvc.Controllers
{
    /// <summary>
    /// SMSController class
    /// controls Twilio functionality
    /// </summary>
    public class SMSController : Controller
    {
        /// <summary>
        /// Sends SMS to supplied phone numbers
        /// </summary>
        /// <param name="to">Customer phone number</param>
        /// <param name="body">SMS body content</param>
        // GET: SMS
        [HttpGet]
        public void SendSms(string to, string body)
        {
            // This is compromising data, but I cannot use environment variables since
            // the solution is not hosted, so, please do not abuse it!
            const string accountSid = "AC7cd74f215c1dfafabf10592d16f800e9";
            const string authToken = "adebbba40d757e1a04bce0676210932d";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: body,
                from: new Twilio.Types.PhoneNumber("+447476552189"),
                to: new Twilio.Types.PhoneNumber(to)
            );

            Console.WriteLine(message.Sid);
        }
    }
}