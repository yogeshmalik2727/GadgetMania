using System;
using System.Collections.Generic;
using System.Text;
using GadgetMania.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GadgetMania.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Category> GadgetManiaCategories { get; set; }

        public DbSet<Products> GadgetManiaProducts { get; set; }

        public DbSet<SupplierReview> GadgetManiaSupplierReview { get; set; }

        public DbSet<Suppliers> Suppliers { get; set; }

        
    }
}
