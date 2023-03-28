using Maxima.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxima.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Product> Product { get; set; }           

            public DbSet<ShoppingCart> ShoppingCarts { get; set; }
            public DbSet<ApplicationUser> ApplicationUsers { get; set; }

            public DbSet<OrderHeader> OrderHeaders { get; set; }
            public DbSet<OrderDetail> OrderDetail { get; set; }

            public DbSet<Size> Size { get; set; }
            public DbSet<AdditionalImg> AdditionalImg { get; set; }




    }
}
