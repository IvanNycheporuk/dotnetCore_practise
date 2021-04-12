using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiction.Infrastructure
{
    public class FictionConfiguration
    {
        public string SenderEmailAddress { get; set; }
        public string SenderEmailPassword { get; set; }
        public string TwilioAccountSid { get; set; }
        public string TwilioAccountAuthToken { get; set; }
        public string TwilioAccountPhoneNumber { get; set; }
        public string RecipientPhoneNumber { get; set; }
    }
}

// create internal classes
