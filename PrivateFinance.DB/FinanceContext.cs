using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PrivateFinance.Entities;

namespace PrivateFinance.DB
{
    public class FinanceContext : DbContext
    {
        public FinanceContext(DbContextOptions<FinanceContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(a => a.Operations);
            modelBuilder.Entity<Operation>()
                .HasOne(a => a.From);
            modelBuilder.Entity<Operation>()
                .HasOne(a => a.To);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryOperation> CategoryOperations { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
