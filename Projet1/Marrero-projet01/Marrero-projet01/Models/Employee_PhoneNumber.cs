using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Marrero_projet01.Models
{
    public class Employee_PhoneNumber //demander au prof, est-ce que ces cles composee sont aussi des cle etrangere ? Si oui, alors il faut que j'enleve les 2 dernieres lignes...
    {
        [Key]
        [Column(Order = 1)]
        public int IdEmployee { get; set; }
        [Key]
        [Column(Order = 2)]
        public int IdPhoneNumber { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public DateTime ModifiedDate { get; set; }

        public virtual Employee_Employee Employee { get; set; } //cle etrangere

        public virtual Employee_PhoneNumberType EmployeePhoneType { get; set; }//cle etrangere


    }
}