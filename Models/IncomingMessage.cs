using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace SymJumbles.Models
{
    public class IncomingMessage
    {
        public int ID { get; set; }

        public string From { get; set; }
        public string To { get; set; }
        public string Body { get; set; }
        public string AccountSid { get; set; }

        public string ToCountry { get; set; }
        public string ToState { get; set; }
        public string SmsMessageSid { get; set; }
        public string NumMedia { get; set; }
        public string ToCity { get; set; }
        public string FromZip { get; set; }
        public string SmsSid { get; set; }
        public string FromState { get; set; }
        public string SmsStatus { get; set; }
        public string FromCity { get; set; }
        public string FromCountry { get; set; }
        public string ToZip { get; set; }
        public string NumSegments { get; set; }
        public string MessageSid { get; set; }
        public string ApiVersion { get; set; }

        
        public string getReverseMessage()
        {            
            List<string> messageParts = SplitWords(Body);
            string newMessage = GlueWordsToMessage(messageParts);
            return newMessage;
        }

        protected List<string> SplitWords(string inputMessage)
        {
            return new List<string>(Regex.Split(inputMessage, @"\s+"));
			// or go by: https://stackoverflow.com/questions/14017886/reverse-words-of-a-sentence-without-using-string-split-in-c-sharp
			// felt like showing the use of a regular expression and using  recursive buildup
        }

        protected string GlueWordsToMessage(List<string> inputMessageParts)
        {
            //return String.Concat(inputMessageParts);
            string returnMessage = "";

            // reverse list
            inputMessageParts.Reverse();

            // concatinate recursively
            ConcatinateWith(" ", inputMessageParts, ref returnMessage);

            return returnMessage;
        }

        protected void ConcatinateWith(string separator, List<string> list, ref string concatinated)
        {
            if (list.Count > 0) 
            {
                concatinated += separator + list[0];
                list.RemoveAt(0);
                ConcatinateWith(separator, list, ref concatinated);
            }              
            return;
        }
    }


}