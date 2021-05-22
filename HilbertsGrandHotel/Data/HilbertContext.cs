using ProjekatPrvaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjekatPrvaApp
{
    public class HilbertContext : DbContext
    {
        public HilbertContext(DbContextOptions<HilbertContext>
       options)
        : base(options)
        {
        }
        public DbSet<Soba> Soba { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Soba>().ToTable("Soba");
        }
    }
}