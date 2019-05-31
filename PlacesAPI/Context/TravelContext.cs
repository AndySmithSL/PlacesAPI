using Microsoft.EntityFrameworkCore;
using PlacesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesAPI.Context
{
    public class TravelContext : DbContext
    {
        public TravelContext(DbContextOptions<TravelContext> options)
            : base(options) { }

        public virtual DbSet<Continent> Continent { get; set; }
        public virtual DbSet<Drive> Drive { get; set; }
        public virtual DbSet<Flag> Flag { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<PlaceGroup> PlaceGroup { get; set; }
        public virtual DbSet<Territory> Territory { get; set; }
        public virtual DbSet<TerritoryType> TerritoryType { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=C:\\Users\\AndyS\\source\\repos\\PlacesAPI\\PlacesAPI\\Database\\Travel.mdf; Integrated Security = True;Connect Timeout=30");
                optionsBuilder.UseSqlServer("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=C:\\Users\\asmith\\source\\repos\\PlacesApi\\PlacesApi\\Database\\Travel.mdf; Integrated Security = True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Continent
            modelBuilder.Entity<Continent>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.HasOne(x => x.Parent)
                    .WithMany(f => f.Children)
                    .HasForeignKey(f => f.ParentId)
                    .HasConstraintName("FK_Continent_Continent");
            });

            // Drive 
            modelBuilder.Entity<Drive>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            // Drive Leg
            modelBuilder.Entity<DriveLeg>(entity =>
            {
                entity.Property(e => e.Number)
                    .IsRequired();

                entity.Property(e => e.DriveId)
                    .IsRequired();

                entity.Property(e => e.OriginId)
                    .IsRequired();

                entity.Property(e => e.DestinationId)
                    .IsRequired();

                entity.HasOne(d => d.Drive)
                    .WithMany(p => p.DriveLegs)
                    .HasForeignKey(d => d.DriveId)
                    .HasConstraintName("FK_DriveLeg_To_Drive");

                entity.HasOne(d => d.Origin)
                    .WithMany(p => p.OriginLegs)
                    .HasForeignKey(d => d.OriginId)
                    .HasConstraintName("FK_DriveLeg_To_Place_Origin");

                entity.HasOne(d => d.Destination)
                    .WithMany(p => p.DestinationLegs)
                    .HasForeignKey(d => d.DestinationId)
                    .HasConstraintName("FK_DriveLeg_To_Place_Destination");
            });

            // Flag
            modelBuilder.Entity<Flag>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Active)
                    .IsRequired();

                entity.Property(e => e.Complete)
                    .IsRequired();
            });

            // Place
            modelBuilder.Entity<Place>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            // Place Group
            modelBuilder.Entity<PlaceGroup>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired();

                entity.Property(e => e.Icon)
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PlaceGroupSet>(entity =>
            {
                entity.HasOne(d => d.Place)
                    .WithMany(p => p.PlaceGroupSets)
                    .HasForeignKey(d => d.PlaceId)
                    .HasConstraintName("FK_PlaceGroupSet_To_Place");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.PlaceGroupSets)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_PlaceGroupSet_To_PlaceGroup");
            });

            modelBuilder.Entity<Territory>(entity =>
            {
                entity.Property(e => e.Isocode)
                    .HasColumnName("ISOCode")
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Continent)
                    .WithMany(p => p.Territories)
                    .HasForeignKey(d => d.ContinentId)
                    .HasConstraintName("FK_Territory_Continent");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Territory_Territory");

                entity.HasOne(d => d.TerritoryType)
                    .WithMany(p => p.Territories)
                    .HasForeignKey(d => d.TerritoryTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Territory_TerritoryType");
            });

            modelBuilder.Entity<TerritoryPlace>(entity =>
            {
                entity.HasOne(d => d.Territory)
                    .WithMany(p => p.TerritoryPlaces)
                    .HasForeignKey(d => d.TerritoryId)
                    .HasConstraintName("FK_TerritoryPlace_Territory");

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.TerritoryPlaces)
                    .HasForeignKey(d => d.PlaceId)
                    .HasConstraintName("FK_TerritoryPlace_Place");
            });

            modelBuilder.Entity<TerritoryType>(entity =>
            {
                entity.Property(e => e.Type).IsRequired();
            });

        }
    }
}
