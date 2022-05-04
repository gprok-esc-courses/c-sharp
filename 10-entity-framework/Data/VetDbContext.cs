using ef_test2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_test2.Data
{
    public class VetDbContext : DbContext 
    {
        public string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=vetclinic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connString);
        }
    }
}
