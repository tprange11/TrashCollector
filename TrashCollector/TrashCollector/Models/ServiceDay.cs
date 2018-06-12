using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

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
        public int ServiceAddressID { get; set; }
        [ForeignKey("ServiceAddressID")]
        public virtual ServiceAddress ServiceAddress { get; set; }
    }
}