using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class SpecialServiceDay
    {
        public int SpecialServiceDayID { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int ServiceAddressID { get; set; }
        [ForeignKey("ServiceAddressID")]
        public virtual ServiceAddress ServiceAddress { get; set; }
    }
}