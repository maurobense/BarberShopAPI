using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BarberShopLogic.Models
{
    public partial class BarberShopContext : DbContext
    {
        public BarberShopContext()
        {
        }

        public BarberShopContext(DbContextOptions<BarberShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barber> Barbers { get; set; }
        public virtual DbSet<BarberBarberShop> BarberBarberShops { get; set; }
        public virtual DbSet<BarberShop> BarberShops { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<TurnBarber> TurnBarbers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost; Database=BarberShop; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Barber>(entity =>
            {
                entity.HasKey(e => e.IdBarber)
                    .HasName("PK__Barber__A3614103DB9C2F23");

                entity.ToTable("Barber");

                entity.HasIndex(e => e.UserName, "UQ__Barber__C9F2845699BA1B72")
                    .IsUnique();

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nickname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBarberShopNavigation)
                    .WithMany(p => p.Barbers)
                    .HasForeignKey(d => d.IdBarberShop)
                    .HasConstraintName("FK__Barber__IdBarber__45F365D3");
            });

            modelBuilder.Entity<BarberBarberShop>(entity =>
            {
                entity.HasKey(e => new { e.IdBarber, e.IdBarberShop })
                    .HasName("PK__BarberBa__0061D5C07ABDC472");

                entity.ToTable("BarberBarberShop");

                entity.HasOne(d => d.IdBarberNavigation)
                    .WithMany(p => p.BarberBarberShops)
                    .HasForeignKey(d => d.IdBarber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BarberBar__IdBar__30F848ED");

                entity.HasOne(d => d.IdBarberShopNavigation)
                    .WithMany(p => p.BarberBarberShops)
                    .HasForeignKey(d => d.IdBarberShop)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BarberBar__IdBar__31EC6D26");
            });

            modelBuilder.Entity<BarberShop>(entity =>
            {
                entity.HasKey(e => e.IdBarber)
                    .HasName("PK__BarberSh__A36141032A1D953E");

                entity.ToTable("BarberShop");

                entity.HasIndex(e => e.Name, "UQ__BarberSh__737584F69F8C4593")
                    .IsUnique();

                entity.HasIndex(e => e.UserName, "UQ__BarberSh__C9F28456B6B1D021")
                    .IsUnique();

                entity.Property(e => e.Adress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.IdBooking)
                    .HasName("PK__Booking__7271F5760BB36137");

                entity.ToTable("Booking");

                entity.HasIndex(e => e.IdTurn, "uniq_turn")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__IdClien__3E52440B");

                entity.HasOne(d => d.IdTurnNavigation)
                    .WithOne(p => p.Booking)
                    .HasForeignKey<Booking>(d => d.IdTurn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__IdTurn__3F466844");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("PK__Client__C1961B33E5EAC270");

                entity.ToTable("Client");

                entity.HasIndex(e => e.Username, "UQ__Client__536C85E445C99587")
                    .IsUnique();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TurnBarber>(entity =>
            {
                entity.HasKey(e => e.IdTurn)
                    .HasName("PK__TurnBarb__9B399A7667D9382B");

                entity.ToTable("TurnBarber");

                entity.HasIndex(e => new { e.Date, e.IdBarber }, "UQ__TurnBarb__5D0E69178010420C")
                    .IsUnique();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.To).HasColumnType("datetime");

                entity.HasOne(d => d.IdBarberNavigation)
                    .WithMany(p => p.TurnBarbers)
                    .HasForeignKey(d => d.IdBarber)
                    .HasConstraintName("FK__TurnBarbe__IdBar__36B12243");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
