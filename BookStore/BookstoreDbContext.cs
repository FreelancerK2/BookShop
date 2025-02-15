using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookStore;

public partial class BookstoreDbContext : DbContext
{
    public BookstoreDbContext()
    {
    }

    public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<Sale> Sales { get; set; } // Add Sales Table
    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-OP5TL27\\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Book__3214EC074ED264A8");

            entity.ToTable("Book");

            entity.Property(e => e.Author).HasMaxLength(255);
            entity.Property(e => e.Discount).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Genre).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PrimeCost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PublishingHouse).HasMaxLength(255);
            entity.Property(e => e.SalePrice).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC07B145F26A");

            entity.ToTable("User");

            entity.HasIndex(e => e.Username, "UQ__User__536C85E488513AE2").IsUnique();

            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sale__3214EC07ABCDEF12");

            entity.ToTable("Sale");

            entity.Property(e => e.SaleDate).HasColumnType("datetime");

            entity.HasOne(s => s.Book)
                  .WithMany()
                  .HasForeignKey(s => s.BookId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        OnModelCreatingPartial(modelBuilder);
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
