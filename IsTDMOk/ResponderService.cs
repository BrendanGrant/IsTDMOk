using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Linq;
using Twilio.TwiML;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace IsTDMOk
{
    public static class ResponderService
    {
        [FunctionName("ResponderService")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var data = await new StreamReader(req.Body).ReadToEndAsync();
            var formValues = data.Split('&')
                .Select(value => value.Split('='))
                .ToDictionary(pair => Uri.UnescapeDataString(pair[0]).Replace("+", " "),
                              pair => Uri.UnescapeDataString(pair[1]).Replace("+", " "));

            bool isValid = false;
            var message = formValues["Body"];
            int number;
            if (int.TryParse(message, out number))
            {
                isValid = true;
                TwilioClient.Init(CommonBits.AccountSid, CommonBits.AuthToken);
                var relayMessage = MessageResource.Create(
                    body: $"A response from {CommonBits.TargetName} been received: {number}",
                    from: new Twilio.Types.PhoneNumber(CommonBits.RelayPhoneNumber),
                    to: new Twilio.Types.PhoneNumber(CommonBits.PhoneNumberToReachOutTo)
                );
            }
            else if( message.ToUpper() == "STOP")
            {
                isValid = true;
                //TODO: Implement some kind of stop feature?
            }
            else
            {
                isValid = false;
            }

            var response = new MessagingResponse()
                .Message(isValid ? CommonBits.AcceptedResponseReply : CommonBits.NotRecognizedResponseReply);
            var twiml = response.ToString();
            twiml = twiml.Replace("utf-16", "utf-8");

            return new HttpResponseMessage
            {
                Content = new StringContent(twiml, Encoding.UTF8, "application/xml")
            };
        }
    }
}
