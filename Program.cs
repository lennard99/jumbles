using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Twilio;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;
using Twilio.Rest.Api.V2010.Account;

namespace SymJumbles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // works // TwilioTestGenericOutput();
            // worked // TwilioTestAccountOutput("+15550000000", "");
          
            BuildWebHost(args).Run();
        }

        protected static void TwilioTestGenericOutput() 
        {
            MessagingResponse twiml = new MessagingResponse();
            twiml.Message("Simple text message.");

            Console.WriteLine(twiml.ToString());
        }                                        
        
        protected static void TwilioTestAccountOutput(string number, string additionalMessage) 
        {
            // Find your Account Sid and Token at twilio.com/console
            const string accountSid = "[accSid]"; // Lennard
            const string authToken = "[authToken]"; // Lennard
            const string fromNumber = "+15876021513"; // Lennard
            string toNumber = number; // Lennard

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Thank you " + number + ". " + additionalMessage,
                from: new Twilio.Types.PhoneNumber(fromNumber),
                to: new Twilio.Types.PhoneNumber(toNumber),
                pathAccountSid: accountSid
            );

            Console.WriteLine(message.Sid);
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
