using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace IsTDMOk
{
    public static class PeriodicReachoutService
    {
        [FunctionName("PeriodicReachoutService")]
        //public static void Run([TimerTrigger("0 */10 * * * *")]TimerInfo myTimer, ILogger log) //Every 10 minutes, for testing purposes.
        public static void Run([TimerTrigger("0 0 17 2 * *")]TimerInfo myTimer, ILogger log) //at 10 AM PST, on every second day of the month.
        {
            TwilioClient.Init(CommonBits.AccountSid, CommonBits.AuthToken);
            
            var relayMessage = MessageResource.Create(
                body: DateTime.Now < new DateTime(2020, 7, 3) ?
                    CommonBits.InitialMessage : 
                    CommonBits.CheckinString,
                from: new PhoneNumber(CommonBits.RelayPhoneNumber),
                to: new PhoneNumber(CommonBits.PhoneNumberToReachOutTo)
            );
        }
    }
}
