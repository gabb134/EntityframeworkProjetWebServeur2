using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Marrero_projet01.Models
{
    public class Entreprise_Entreprise
    {
        public int IdEntreprise { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public string EntrepriseName { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public string EntrepriseNote { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public DateTime DateInscrit { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public DateTime DateMod { get; set; }

        public virtual ICollection<Entreprise_Address> Entreprise_Addresses { get; set; }//Entreprise ont plusieurs adresses
        public virtual ICollection<Employee_Employee> Employee_Employees { get; set; } //Entreprise ont plusieurs employess


    }
}