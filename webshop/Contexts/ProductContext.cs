using System;
using Microsoft.EntityFrameworkCore;
using webshop;

public class ProductContext : DbContext
{

    public ProductContext(DbContextOptions<ProductContext> options)
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=DB/products.db");
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        Product p = new Product {Id = 1, Name = "Ball", Price = 120, ImageUrl = "https://sportshub.cbsistatic.com/i/r/2019/05/03/d6c40a6b-f986-4a8a-bc3d-01834e93e83d/thumbnail/1200x675/91edc3740160d04e8b3a4b46ce19bad5/major-league-baseball-ball.jpg", Description = "Nice Ball"};
        Order o = new Order {Id = 1, companyId = 1, totalPrice = 120, status = "done", paymentMethod = "Visa", created = DateTime.Now, createdBy = "me"};
        modelBuilder.Entity<Product>().HasData(p);
        modelBuilder.Entity<Order>().HasData(o);

        modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail{Id = 1, ProductId = p.Id, OrderId = o.Id });
        
    }

}