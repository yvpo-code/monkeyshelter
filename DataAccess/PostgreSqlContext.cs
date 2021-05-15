using Microsoft.EntityFrameworkCore;  
using PostgresCRUD.Models;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
  
namespace PostgresCRUD.DataAccess  
{  
    public class PostgreSqlContext: DbContext  
    {  
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)  
        {  
        }  
  
        public DbSet<Monkey> monkeys { get; set; }  
        public DbQuery<SpeciesCount> Reports { get; set; }  
  
        protected override void OnModelCreating(ModelBuilder builder)  
        {  
            base.OnModelCreating(builder); 
        }  
  
        public override int SaveChanges()  
        {  
            ChangeTracker.DetectChanges();  
            return base.SaveChanges();  
        }

    }  
}