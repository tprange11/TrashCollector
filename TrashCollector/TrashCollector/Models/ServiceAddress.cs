using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollector.Models
{
    public class ServiceAddress
    {
        public int ServiceAddressID { get; set; }

        [Display(Name = "Address 1")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        public string City { get; set; }

        [Display(Name = "State")]
        public int StateID { get; set; }

        [ForeignKey("StateID")]
        public virtual State State { get; set; }

        [DataType(DataType.PostalCode)]
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        public virtual ICollection ServiceDay { get; set; }

        public virtual ICollection SpecialServiceDays { get; set; }
        [Display(Name ="First Name")]
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }

    }
}