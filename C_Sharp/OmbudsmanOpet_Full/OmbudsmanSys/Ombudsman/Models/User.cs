using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ombudsman.Models
{
    public class User
    {
        public long UserId { get; set; }
        [Display(Name = "Cpf")]
        [Required(ErrorMessage = "Cpf required")]
        public string CpfUser { get; set; }
        [Required(ErrorMessage = "Name required")]
        [Display(Name = "Name")]
        public string UserName { get; set; }
        [Display(Name = "Genre")]
        public string UserGenre { get; set; }
        [Required(ErrorMessage = "Login required")]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter password")]        
        public string Password { get; set; }
        [Required(ErrorMessage = "Enter pin")]
        public long? Pin { get; set; }
        public bool Admin { get; set; }

        public virtual ICollection<Manifestation> Manifestations { get; set; }
        public virtual ICollection<Telephone> Telephones { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Adress> Adresses { get; set; }
    }
}