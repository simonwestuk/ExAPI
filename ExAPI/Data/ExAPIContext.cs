using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ExAPI.Data
{
    public class ExAPIContext : IdentityDbContext
    {
        public ExAPIContext (DbContextOptions<ExAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ExAPI.Models.Activity> Activity { get; set; }
    }
}
