﻿// <auto-generated />
using System;
using HilbertsGrandHotel_KP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HilbertsGrandHotel_KP.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210613010651_SefInstance")]
    partial class SefInstance
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HilbertsGrandHotel_KP.Models.NaplataRecepcioner", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("iznos")
                        .HasColumnType("float");

                    b.Property<string>("korisnikId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("sobaID")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("korisnikId");

                    b.HasIndex("sobaID");

                    b.ToTable("NaplataRecepcioner");
                });

            modelBuilder.Entity("HilbertsGrandHotel_KP.Models.OdjavaRezervacije", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("korisnikId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("sobaID")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("korisnikId");

                    b.HasIndex("sobaID");

                    b.ToTable("OdjavaRezervacije");
                });

            modelBuilder.Entity("HilbertsGrandHotel_KP.Models.Recenzija", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("datum")
                        .HasColumnType("datetime2");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sobaID")
                        .HasColumnType("int");

                    b.Property<string>("tekst")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("sobaID");

                    b.ToTable("Recenzija");
                });

            modelBuilder.Entity("HilbertsGrandHotel_KP.Models.Uplata", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("iznos")
                        .HasColumnType("int");

                    b.Property<int>("odgovornoLiceID")
                        .HasColumnType("int");

                    b.Property<string>("uplatiocId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("vrstaUplate")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("odgovornoLiceID");

                    b.HasIndex("uplatiocId");

                    b.ToTable("Uplata");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HilbertsGrandHotel_KP.Models.Korisnik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("HilbertsGrandHotel_KP.Models.Osoblje", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("adresaStanovanja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("aspUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("brojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uloga")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("aspUserId");

                    b.ToTable("Osoblje");
                });

            modelBuilder.Entity("HilbertsGrandHotel_KP.Models.Recepcioner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("adresaStanovanja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("aspUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("brojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sveSobe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("aspUserId");

                    b.ToTable("Recepcioner");
                });

            modelBuilder.Entity("HilbertsGrandHotel_KP.Models.Rezervacija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("korisnikId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("sobaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("korisnikId");

                    b.HasIndex("sobaID");

                    b.ToTable("Rezervacija");
                });

            modelBuilder.Entity("HilbertsGrandHotel_KP.Models.Sef", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("adresaStanovanja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("aspUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("brojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("listaOsoblja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("aspUserId");

                    b.ToTable("Sef");
                });

            modelBuilder.Entity("HilbertsGrandHotel_KP.Models.Soba", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("brojGostiju")
                        .HasColumnType("int");

                    b.Property<int>("brojKreveta")
                        .HasColumnType("int");

                    b.Property<double>("cijena")
                        .HasColumnType("float");

                    b.Property<DateTime>("datumOdjave")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("datumPrijave")
                        .HasColumnType("datetime2");

                    b.Property<string>("korisnikId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("stanjeSobe")
                        .HasColumnType("int");

                    b.Property<bool>("zauzetostSobe")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("korisnikId");

                    b.ToTable("Soba");
                });

            modelBuilder.Entity("HilbertsGrandHotel_KP.Data.MojRegisteredUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasDiscriminator().HasValue("MojRegisteredUser");
                });

            modelBuilder.Entity("HilbertsGrandHotel_KP.Models.NaplataRecepcioner", b =>
                {
                    b.HasOne("HilbertsGrandHotel_KP.Data.MojRegisteredUser", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HilbertsGrandHotel_KP.Models.Soba", "soba")
                        .WithMany()
                        .HasForeignKey("sobaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HilbertsGrandHotel_KP.Models.OdjavaRezervacije", b =>
                {
                    b.HasOne("HilbertsGrandHotel_KP.Data.MojRegisteredUser", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HilbertsGrandHotel_KP.Models.Soba", "soba")
                        .WithMany()
                        .HasForeignKey("sobaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HilbertsGrandHotel_KP.Models.Recenzija", b =>
                {
                    b.HasOne("HilbertsGrandHotel_KP.Models.Soba", "soba")
                        .WithMany()
                        .HasForeignKey("sobaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HilbertsGrandHotel_KP.Models.Uplata", b =>
                {
                    b.HasOne("HilbertsGrandHotel_KP.Models.Recepcioner", "odgovornoLice")
                        .WithMany()
                        .HasForeignKey("odgovornoLiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HilbertsGrandHotel_KP.Data.MojRegisteredUser", "uplatioc")
                        .WithMany()
                        .HasForeignKey("uplatiocId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HilbertsGrandHotel_KP.Models.Osoblje", b =>
                {
                    b.HasOne("HilbertsGrandHotel_KP.Data.MojRegisteredUser", "aspUser")
                        .WithMany()
                        .HasForeignKey("aspUserId");
                });

            modelBuilder.Entity("HilbertsGrandHotel_KP.Models.Recepcioner", b =>
                {
                    b.HasOne("HilbertsGrandHotel_KP.Data.MojRegisteredUser", "aspUser")
                        .WithMany()
                        .HasForeignKey("aspUserId");
                });

            modelBuilder.Entity("HilbertsGrandHotel_KP.Models.Rezervacija", b =>
                {
                    b.HasOne("HilbertsGrandHotel_KP.Data.MojRegisteredUser", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HilbertsGrandHotel_KP.Models.Soba", "soba")
                        .WithMany()
                        .HasForeignKey("sobaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HilbertsGrandHotel_KP.Models.Sef", b =>
                {
                    b.HasOne("HilbertsGrandHotel_KP.Data.MojRegisteredUser", "aspUser")
                        .WithMany()
                        .HasForeignKey("aspUserId");
                });

            modelBuilder.Entity("HilbertsGrandHotel_KP.Models.Soba", b =>
                {
                    b.HasOne("HilbertsGrandHotel_KP.Data.MojRegisteredUser", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnikId");
                });
#pragma warning restore 612, 618
        }
    }
}
