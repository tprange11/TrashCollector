using System;
using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class SpecialServiceDay
    {
        public int SpecialServiceDayID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int ServiceAddressID { get; set; }
        public virtual ServiceAddress ServiceAddress { get; set; }
    }
}