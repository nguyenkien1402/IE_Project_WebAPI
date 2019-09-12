using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace XBrain.Models
{
    public partial class XBrainContext : DbContext
    {
        public XBrainContext()
        {
        }

        public XBrainContext(DbContextOptions<XBrainContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DailyActivity> DailyActivity { get; set; }
        public virtual DbSet<DailyRoutine> DailyRoutine { get; set; }
        public virtual DbSet<XbrainUser> XbrainUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=KIENNT;Database=XBrain;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<DailyActivity>(entity =>
            {
                entity.Property(e => e.ActivityContent).HasMaxLength(250);

                entity.Property(e => e.ActivityTitle)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateAchieve).HasColumnType("date");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DailyActivity)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DailyActi__UserI__403A8C7D");
            });

            modelBuilder.Entity<DailyRoutine>(entity =>
            {
                entity.Property(e => e.DateAchieve).HasColumnType("date");

                entity.Property(e => e.DayOperation).HasMaxLength(100);

                entity.Property(e => e.RoutineTitle)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DailyRoutine)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DailyRout__Actua__3B75D760");
            });

            modelBuilder.Entity<XbrainUser>(entity =>
            {
                entity.ToTable("XBrainUser");

                entity.Property(e => e.DeviceId).HasMaxLength(250);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.HashPassword).HasMaxLength(250);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.UserName).HasMaxLength(100);
            });
        }
    }
}
