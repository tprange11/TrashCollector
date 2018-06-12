using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class ServiceAddress
    {
        public int ServiceAddressID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int StateID { get; set; }
        [ForeignKey("StateID")]
        public virtual State State { get; set;}
        [DataType(DataType.PostalCode)]
        public int ZipCode { get; set; }


    }
}