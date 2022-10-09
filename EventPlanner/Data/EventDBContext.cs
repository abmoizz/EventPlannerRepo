using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventPlanner.Data
{
    public partial class EventDBContext : DbContext
    {
        public EventDBContext()
        {
        }

        public EventDBContext(DbContextOptions<EventDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EventDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.EventDate)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EventName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
