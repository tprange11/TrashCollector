using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class State
    {
        public int StateID { get; set; }

        [Display(Name = "State")]
        public string Name { get; set; }
    }
}