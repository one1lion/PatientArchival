using Microsoft.EntityFrameworkCore;
using PatientArchive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientArchive.API.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Direport>().HasKey(x => new { x.FileId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Direport> Direports { get; set; }
        
    }
}
