using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollector.Models
{
    public class ServiceDay
    {
        public int ServiceDayID { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public string Frequency { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Suspend Service From")]
        public DateTime? BeginDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Suspend Service To")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Service Address")]
        public int ServiceAddressID { get; set; }

        [ForeignKey("ServiceAddressID")]
        [Display(Name = "Service Address")]
        public virtual ServiceAddress ServiceAddress { get; set; }
    }
}