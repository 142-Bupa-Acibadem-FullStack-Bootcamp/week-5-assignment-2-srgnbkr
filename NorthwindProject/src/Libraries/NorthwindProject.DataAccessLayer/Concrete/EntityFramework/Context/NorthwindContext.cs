using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NorthwindProject.Entities.Models;

#nullable disable

namespace NorthwindProject.DataAccessLayer.Concrete.EntityFramework.Context
{
    public partial class NorthwindContext : DbContext
    {

        //DB bağlantı için yöntem 1
        //IConfiguration configuration;
        //public NORTHWNDContext(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //}

        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }

        


        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerCustomerDemo> CustomerCustomerDemos { get; set; }
        public virtual DbSet<CustomerDemographic> CustomerDemographics { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Territory> Territories { get; set; }
        public virtual DbSet<User> Users { get; set; }


























    }
}
