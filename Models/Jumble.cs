using System;
//using System.ComponentModel.DataAnnotations;

namespace MyApp1.Models
{
    public class Jumble
    {
        public int ID { get; set; }
        public string MessageIn { get; set; }
        public string MessageOut { get; set; }
        public string NumberTo { get; set; }
        public string NumberFrom { get; set; }
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:ii:ss", ApplyFormatInEditMode = true)]
        public DateTime TimeStamp { get; set; }
    }
}