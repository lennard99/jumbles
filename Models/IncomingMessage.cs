using System;

namespace MyApp1.Models
{
    public class IncomingMessage
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Body { get; set; }
        public string AccountSid { get; set; }
    }
}