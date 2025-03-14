﻿using Microsoft.EntityFrameworkCore;
using Trading_Company.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<WarehouseItem> WarehouseItems { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<SupplyOrder> SupplyOrders { get; set; }
    public DbSet<SupplyOrderDetail> SupplyOrderDetails { get; set; }
    public DbSet<CustomerOrder> CustomerOrders { get; set; }
    public DbSet<CustomerOrderDetail> CustomerOrderDetails { get; set; }
    public DbSet<TransferOrder> TransferOrders { get; set; }
    public DbSet<TransferOrderDetail> TransferOrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Trade_Company;Integrated Security=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Composite Keys
        modelBuilder.Entity<WarehouseItem>().HasKey(wi => new { wi.WarehouseID, wi.ItemID });
        modelBuilder.Entity<SupplyOrderDetail>().HasKey(sd => new { sd.SupplyOrderID, sd.ItemID });
        modelBuilder.Entity<CustomerOrderDetail>().HasKey(wd => new { wd.CustomerOrderID, wd.ItemID });
        modelBuilder.Entity<TransferOrderDetail>().HasKey(td => new { td.TransferOrderID, td.ItemID });

        modelBuilder.Entity<TransferOrder>()
            .HasOne(to => to.SourceWarehouse)
            .WithMany()
            .HasForeignKey(to => to.SourceWarehouseID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TransferOrder>()
            .HasOne(to => to.DestinationWarehouse)
            .WithMany()
            .HasForeignKey(to => to.DestinationWarehouseID)
            .OnDelete(DeleteBehavior.Restrict);
    }

}
