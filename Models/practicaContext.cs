using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TMSApi.Models
{
    public partial class practicaContext : DbContext
    {
        public practicaContext()
        {
        }

        public practicaContext(DbContextOptions<practicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EventType> EventTypes { get; set; }
        public virtual DbSet<Eventss> Eventsses { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<TicketCategory> TicketCategories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Venue> Venues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-0TC0N5U;Initial Catalog=practica;Integrated Security=True;TrustServerCertificate=True;encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.ToTable("event_type");

                entity.HasIndex(e => e.EventTypeName, "UQ__event_ty__04BC409E653266C0")
                    .IsUnique();

                entity.Property(e => e.EventTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("event_type_id");

                entity.Property(e => e.EventTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("event_type_name");
            });

            modelBuilder.Entity<Eventss>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK__eventss__2370F727305A05A8");

                entity.ToTable("eventss");

                entity.Property(e => e.EventId)
                    .ValueGeneratedNever()
                    .HasColumnName("event_id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.EventDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("event_description");

                entity.Property(e => e.EventName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("event_name");

                entity.Property(e => e.EventTypeId).HasColumnName("event_type_id");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date");

                entity.Property(e => e.VenueId).HasColumnName("venue_id");

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.Eventsses)
                    .HasForeignKey(d => d.EventTypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_eventTypeId");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Eventsses)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_venueID");
            });

          
     
        
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.NumberOfTickets).HasColumnName("number_of_tickets");

                entity.Property(e => e.OrderTotalPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("order_total_price");

                entity.Property(e => e.OrderedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("ordered_at");

                entity.Property(e => e.TicketCategoryId).HasColumnName("ticket_category_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.TicketCategory)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TicketCategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_order_ticketID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_order_userID");
            });

            modelBuilder.Entity<TicketCategory>(entity =>
            {
                entity.ToTable("ticket_category");

                entity.Property(e => e.TicketCategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("ticket_category_id");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.TicketCategoryDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ticket_category_description");

                entity.Property(e => e.TicketCategoryPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("ticket_category_price");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.TicketCategories)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_category_eventID");
            });

          
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "UQ__users__AB6E616458DC7909")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Venue>(entity =>
            {
                entity.ToTable("venue");

                entity.Property(e => e.VenueId)
                    .ValueGeneratedNever()
                    .HasColumnName("venue_id");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("location_name");

                entity.Property(e => e.LocationType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("location_type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
