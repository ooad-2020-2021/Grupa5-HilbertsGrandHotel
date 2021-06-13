using HilbertsGrandHotel_KP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HilbertsGrandHotel_KP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HilbertsGrandHotel_KP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Soba> Soba { get; set; }

        public DbSet<Korisnik> Korisnik { get; set; }

        public DbSet<Osoblje> Osoblje { get; set; }

        public DbSet<Recepcioner> Recepcioner { get; set; }

        public DbSet<Sef> Sef { get; set; }

        public DbSet<Rezervacija> Rezervacija { get; set; }

        public DbSet<HilbertsGrandHotel_KP.Models.Recenzija> Recenzija { get; set; }

        public DbSet<Uplata> Uplata { get; set; }

        public DbSet<NaplataRecepcioner> NaplataRecepcioner { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Soba>().ToTable("Soba");
            modelBuilder.Entity<Korisnik>().ToTable("Korisnik");
            modelBuilder.Entity<Osoblje>().ToTable("Osoblje");
            modelBuilder.Entity<Recepcioner>().ToTable("Recepcioner");
            modelBuilder.Entity<Sef>().ToTable("Sef");
            modelBuilder.Entity<Rezervacija>().ToTable("Rezervacija");
            modelBuilder.Entity<Uplata>().ToTable("Uplata");
            modelBuilder.Entity<NaplataRecepcioner>().ToTable("NaplataRecepcioner");
            modelBuilder.Entity<MojRegisteredUser>()
               .Property(e => e.firstName)
               .HasMaxLength(250);

            modelBuilder.Entity<MojRegisteredUser>()
                .Property(e => e.lastName)
                .HasMaxLength(250);


            base.OnModelCreating(modelBuilder);
        }
        public DbSet<HilbertsGrandHotel_KP.Models.OdjavaRezervacije> OdjavaRezervacije { get; set; }


    }
}
