using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Marrero_projet01.Models
{
    public class Entreprise_AddressType
    {
        [Key]
        public int AddressTypeID { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public string AddressType { get; set; }
      //  [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public DateTime  ModifiedDate { get; set; }

        public virtual ICollection<Entreprise_Address> EntrepriseAdresses { get; set; } // un type adresse peut contenir plisuers entreprises
    }
}