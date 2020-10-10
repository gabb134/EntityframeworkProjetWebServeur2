using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Marrero_projet01.Models
{
    public class Entreprise_AddressType
    {
        public int IdPhoneNumberType { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public string PhoneNumberType { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public DateTime  ModifiedDate { get; set; }

        public virtual ICollection<Entreprise_Address> EntrepriseAdresses { get; set; } // un type adresse peut contenir plisuers entreprises
    }
}