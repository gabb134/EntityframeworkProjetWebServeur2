﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Marrero_projet01.Models
{
    public class Entreprise_Address //Une adresse d'entreprise a un ou plusieurs types d'adresses
                                    //Une adresse d'entreprise est associe a un et une seul entreprise
    {

        public int IdAddress { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public string City { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public string Province { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public string EntrepriseAddWeb { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire!")]
        public DateTime ModifiedDate { get; set; }

     public virtual Entreprise_AddressType AddressType { get; set; }//cle etrangere

        public virtual Entreprise_Entreprise Entreprise { get; set; }//cle etrangere

    }
}