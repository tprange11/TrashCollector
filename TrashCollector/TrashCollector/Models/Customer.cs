using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public int ServiceAddressID { get; set; }

        public virtual ICollection ServiceAddresses { get; set; }
    }
}