using System;
using System.Collections.Generic;
using System.Text;
using Automobile.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Automobile.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        internal object automobile_brand;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<automobile_brand> automobile_brands { get; set; }
        public DbSet<product> products { get; set; }
    }
}
