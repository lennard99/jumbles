using System;
//using System.ComponentModel.DataAnnotations;

namespace SymJumbles.Models
{
    public class Jumble
    {
        public int ID { get; set; }

        public string MessageIn { get; set; }
        public string MessageOut { get; set; }
        public string NumberTo { get; set; }
        public string NumberFrom { get; set; }
        /// [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:ii:ss", ApplyFormatInEditMode = true)]
        public DateTime TimeStamp { get; set; }
        
        public Jumble()
        {
        }

        // Constructor using an IncomingMessage
        public Jumble(IncomingMessage incomingMessage)
        {   
            MessageIn = incomingMessage.Body;    
            MessageOut = incomingMessage.getReverseMessage();
            NumberFrom = incomingMessage.From;
            NumberTo = incomingMessage.To;
            TimeStamp = DateTime.Now;
        }

    }

    

}