using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ombudsman.Models
{
    public class Protester
    {
        public long ProtesterId { get; set; }
        [Display(Name = "Cpf")]
        [Required(ErrorMessage = "Enter cpf")]
        public int ProtesterCpf { get; set; }
        [Required(ErrorMessage = "Enter name")]
        [Display(Name = "Name")]
        public string ProtesterName { get; set; }
        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Enter genre M/F")]
        public string ProtesterGenre { get; set; }

        public virtual ICollection<Manifestation> Manifestations { get; set; }
        public virtual ICollection<Telephone> Telephones { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Adress> Adresses { get; set; }
    }
}