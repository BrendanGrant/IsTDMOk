using System;
using System.Collections.Generic;
using System.Text;

namespace IsTDMOk
{
    static internal class CommonBits
    {
        public static string AccountSid => Environment.GetEnvironmentVariable("TwilioAccountSid");
        public static string AuthToken => Environment.GetEnvironmentVariable("TwilioAuthToken");

        public static string PhoneNumberToReachOutTo => Environment.GetEnvironmentVariable("PhoneNumberToReachOutTo");
        public static string RelayPhoneNumber => Environment.GetEnvironmentVariable("RelayPhoneNumber");
        public static string PhoneNumberToReportTo => Environment.GetEnvironmentVariable("PhoneNumberToReportTo");
        public static string TargetName => Environment.GetEnvironmentVariable("TargetName");
        public static string AilmentName => Environment.GetEnvironmentVariable("AilmentName");
        public static string SenderName => Environment.GetEnvironmentVariable("SenderName");
        public static string SubjectivePronoun => Environment.GetEnvironmentVariable("SubjectivePronoun");
        public static string PosessivePronoun => Environment.GetEnvironmentVariable("PosessivePronoun");

        public static string ScaleString =>
            string.Join(Environment.NewLine,
                new[]
                {
                    $"1 - {SubjectivePronoun} won",
                    "2 - Turn for the better",
                    "3 - Ongoing",
                    "4 - Turn for the worse",
                    $"5 - {SubjectivePronoun} lost"
                });

        public static string InitialMessageIntro =>
            string.Join(Environment.NewLine + Environment.NewLine,
                new[]
                {
                    "This is the inaugural test of the IsTDMOk service.",
                    $"I am a simple bot, commissioned by {SenderName}. I will periodically ping this phone number to inquire if {TargetName} is ok or not {AilmentName}wise.",
                    "I only accept numeric responses in query. I do not support an \"I want to talk to the manager\" mode, nor any other messages.",
                    "My source code can be seen at: https://github.com/BrendanGrant/IsTDMOk (steps were taken to ensure personal information not end up there)",
                    $"Note: {SenderName}'s contact information is attached to that source code, however {TargetName} lacks the technical ability to figure out how find it. Doing so would require asking for help from the last person {SubjectivePronoun.ToLower()} would want to ask." }
                );

        public static string InitialMessage => 
            string.Join(Environment.NewLine + Environment.NewLine,
                new[]
                {
                    InitialMessageIntro,
                    CheckinString
                });

        public static string CheckinString =>
            string.Join(Environment.NewLine + Environment.NewLine,
                new[]
                {
                   $"This is a periodic check on {TargetName}, what is the status of {PosessivePronoun.ToLower()} {AilmentName}?",
                   "Please reply with one of the following (number only) responses. Note: No invalid responses will be relayed.",
                   ScaleString
                });


        public static string AcceptedResponseReply = "Your response has been noted and will be relayed, thanks.";
        public static string NotRecognizedResponseReply =>
            string.Join(Environment.NewLine + Environment.NewLine,
                new[]
                {
                    "I'm sorry, I don't understand your response. Please respond with a numeric value.",
                    ScaleString
                });
    }
}
