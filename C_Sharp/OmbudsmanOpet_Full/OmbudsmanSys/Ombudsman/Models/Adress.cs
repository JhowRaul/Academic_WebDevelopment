using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ombudsman.Models
{
    public class Adress
    {
        public long AdressId { get; set; }
        public string Country { get; set; }
        [Required(ErrorMessage = "Enter state")]
        public string State { get; set; }
        [Required(ErrorMessage = "Enter city")]
        public string City { get; set; }
        [Required(ErrorMessage = "Enter Neighborhood")]
        public string Neighborhood { get; set; }
        public long? ZipCode { get; set; }
        [Required(ErrorMessage = "Enter street")]
        public string Street { get; set; }
        [Display(Name = "Type of street")]
        public string TypePatioArea { get; set; }
        [Display(Name = "Public place")]
        public string PatioAreaName { get; set; }
        [Required(ErrorMessage = "Enter the batch number")]
        public int Lot { get; set; }

        public virtual ICollection<Protester> Protesters { get; set; }

    }
}