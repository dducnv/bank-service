using System.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace bank_service
{
       public class SmsService : IIdentityMessageService
        {
            public Task SendAsync(IdentityMessage message)
            {
                // Twilio Begin
                var accountSid = ConfigurationManager.AppSettings["SMSAccountIdentification"];
                var authToken = ConfigurationManager.AppSettings["SMSAccountPassword"];
                var fromNumber = ConfigurationManager.AppSettings["SMSAccountFrom"];

                TwilioClient.Init(accountSid, authToken);

                MessageResource result = MessageResource.Create(
                new PhoneNumber(message.Destination),
                from: new PhoneNumber(fromNumber),
                body: message.Body
                );

                ////Status is one of Queued, Sending, Sent, Failed or null if the number is not valid
                Trace.TraceInformation(result.Status.ToString());
                ////Twilio doesn't currently have an async API, so return success.
                return Task.FromResult(0);
                // Twilio End
                // Plug in your SMS service here to send a text message.
            }
    }
}
