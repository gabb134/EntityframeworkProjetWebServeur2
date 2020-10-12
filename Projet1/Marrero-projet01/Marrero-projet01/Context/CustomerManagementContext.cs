using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Marrero_projet01.Models;

namespace Marrero_projet01.Context
{
    public class CustomerManagementContext : DbContext
    {
        public CustomerManagementContext() : base("CustomerManagementContextDB")
        {

        }
        public DbSet<Employee_Employee> Employes { get; set; }
        public DbSet<Employee_PhoneNumber> EmployesNumeros { get; set; }
        public DbSet<Employee_PhoneNumberType> NumeroTypes { get; set; }
        public DbSet<Entreprise_Address> Addresses { get; set; }
        public DbSet<Entreprise_AddressType> AddressesTypes { get; set; }
        public DbSet<Entreprise_Entreprise> Entreprises { get; set; }

        

    }
}