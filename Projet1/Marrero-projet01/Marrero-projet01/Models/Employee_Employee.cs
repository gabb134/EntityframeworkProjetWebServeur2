using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Marrero_projet01.Models
{
    public class Employee_Employee
    {
        /*EmployeeID] int IDENTITY(1,1) NOT NULL,
    [EntrepriseID] int  NOT NULL,	
    [FirstName] varchar(50)  NOT NULL,
    [MiddleName] varchar(50)  NULL,
    [LastName] varchar(50)  NOT NULL,
	[Gender] nvarchar(8)  NULL,
    [EmailAddress] nvarchar(50)  NULL,
    [Titre] nvarchar(50)  NOT NULL,
	[Department] nvarchar(50)  NOT NULL,
    [ModifiedDate*/

        public int IdEmployee { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public string Titre { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public string Departement { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public DateTime ModifiedDate { get; set; }



        public virtual Entreprise_Entreprise Entreprise { get; set; }//cle etrangere
        public virtual ICollection<Employee_PhoneNumber> EmployeeNumeros { get; set; } //Emplyee peut avoir plisuers numeros


    }
}