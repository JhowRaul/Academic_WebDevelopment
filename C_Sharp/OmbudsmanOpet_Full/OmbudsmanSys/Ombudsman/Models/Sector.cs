using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ombudsman.Models
{
    public class Sector
    {
        public long SectorId { get; set; }
        [Display(Name = "Sector")]
        [Required(ErrorMessage = "Enter a sector")]
        public string SectorDescription { get; set; }
    }
}