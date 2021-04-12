using Fiction.Infrastructure;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Fiction.Services
{
    public class SmsMessageSender : IMessageSender
    {

        private readonly FictionConfiguration _fictionConfiguration;

        public SmsMessageSender(IOptions<FictionConfiguration> options)
        {
            _fictionConfiguration = options.Value;
        }

        public void SendMessage()
        {
            string accountSid = _fictionConfiguration.TwilioAccountSid;
            string authToken = _fictionConfiguration.TwilioAccountAuthToken;

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "This is the ship that made the Kessel Run in fourteen parsecs?",
                from: new Twilio.Types.PhoneNumber(_fictionConfiguration.TwilioAccountPhoneNumber),
                to: new Twilio.Types.PhoneNumber(_fictionConfiguration.RecipientPhoneNumber)
            );

            Console.WriteLine(message.Sid);
        }
    }
}

