using Cafe.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Core.Entities.Concrete;
using Microsoft.Extensions.Configuration;


namespace Cafe.DataAccess.Concrete.EntityFramework.MSSQL.Context
{
    public class CafeContext : DbContext
    {
      


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
              optionsBuilder.UseSqlServer((@"Server=(localdb)\mssqllocaldb;Database=Cafe;Trusted_Connection=true"));
            
           
        }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Dessert> Desserts { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Person> Persons { get; set; }




    }
}
