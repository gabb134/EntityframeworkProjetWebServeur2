using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Marrero_projet01.Models
{
    public class Employee_PhoneNumberType
    {
        [Key]
        public int PhoneNumberTypeID {get; set;}
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public string PhoneNumbertype { get; set; }
    //    [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Employee_PhoneNumber> EmployeeNumeros { get; set; } // pour untype de numeros, il peut avoir pluseurs nunmerios sur ce type

    }
}