using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.Models;

public partial class dbcontext : DbContext
{
    public dbcontext()
    {
    }

    public dbcontext(DbContextOptions<dbcontext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<ItemOreder> ItemOreders { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Purveyor> Purveyors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\בסד אסתי נחמי וחני\\c\\Uniform\\dataBase.mdf\";Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.InstituteId).HasName("PK__Customer__93C33C5BE9508EE6");

            entity.Property(e => e.InstituteId).HasColumnName("Institute id");
            entity.Property(e => e.Address)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(25)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("email");
            entity.Property(e => e.InstituteName)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Institute name");
            entity.Property(e => e.OverPluseDebt)
                .HasDefaultValueSql("((0))")
                .HasColumnType("money")
                .HasColumnName("overPluse/debt");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("phone");
            entity.Property(e => e.SellingPlace)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("selling place");
        });

        modelBuilder.Entity<ItemOreder>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId });

            entity.ToTable("ItemOreder");

            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Qty).HasColumnName("qty");

            entity.HasOne(d => d.Order).WithMany(p => p.ItemOreders)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemOreder_ToTable_2");

            entity.HasOne(d => d.Product).WithMany(p => p.ItemOreders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemOreder_ToTable_1");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.InstituteId).HasColumnName("Institute id");
            entity.Property(e => e.OrderDate)
                .HasColumnType("date")
                .HasColumnName("orderDate");
            entity.Property(e => e.SupplyDate)
                .HasColumnType("date")
                .HasColumnName("supplyDate");
            entity.Property(e => e.ToatlSum).HasColumnName("toatl sum");

            entity.HasOne(d => d.Institute).WithMany(p => p.Orders)
                .HasForeignKey(d => d.InstituteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Table_ToTable");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC073E318621");

            entity.Property(e => e.Dscribe)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("dscribe");
            entity.Property(e => e.IdPurveyor).HasColumnName("idPurveyor");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductName)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("productName");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.IdPurveyorNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdPurveyor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_ToTable");
        });

        modelBuilder.Entity<Purveyor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Purveyor__3214EC076A897AAF");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(25)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("company name");
            entity.Property(e => e.Email)
                .HasMaxLength(25)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
