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

namespace myApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // works // TwilioTestGenericOutput();
            // works // TwilioTestAccountOutput();
          
            BuildWebHost(args).Run();
        }

        protected static void TwilioTestGenericOutput() 
        {
            var twiml = new MessagingResponse();
            twiml.Message("Simple text message.");

            Console.WriteLine(twiml.ToString());
        }                                        
        
        protected static void TwilioTestAccountOutput() 
        {
            // Find your Account Sid and Token at twilio.com/console
            const string accountSid = ""; // Lennard
            const string authToken = ""; // Lennard
            const string fromNumber = ""; // Lennard
            const string toNumber = ""; // Lennard

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Sid message.",
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
