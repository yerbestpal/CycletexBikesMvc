// name: Ross McLean
// date: 16/05/20

using System;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

// Twilio SMS notification
// This will not work with any number other than my own, unless verified, because
// I am using a Twilio trial account for this implementation.
// Otherwise, I would have to pay for a digital phone number.
// I will include screenshots of it working with my (verified) number, but with
// the project submission and my evaluation.

/*If you want to see it working for yourself, email me and I can add your number to the list of verified numbers*/

// I did not realise this was the issue until I saw this message in debugging:
/*{"The number  is unverified. Trial accounts cannot send messages to unverified numbers; verify  at 
 * twilio.com/user/account/phone-numbers/verified, or purchase a Twilio number to send messages to unverified numbers."}*/

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
            const string authToken = "09cf306f3e69e2bdcd26d6aa575ce2a0";

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