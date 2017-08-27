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
