using System;
using Microsoft.EntityFrameworkCore;
using webshop;

public class WebshopContext : DbContext {

    public WebshopContext(DbContextOptions<WebshopContext> options)
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=DB/webshop.db");
    }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Order_Detail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    
    


    /* protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        Order o = new Order {Id = 1, companyId = 707, totalPrice = 120, status = "done", paymentMethod = "Visa", created = DateTime.Now, createdBy = "me"};

        modelBuilder.Entity<Order>().HasData(o);

        modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail{Id = 1, ProductId = p.Id, OrderId = o.products });
        
    } */


    /* protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            base.OnModelCreating(modelBuilder);
        
            



            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>().HasKey(p => new {p.Id});

            modelBuilder.Entity<Order_Detail>().ToTable("OrderDetails");
            modelBuilder.Entity<Order_Detail>().HasKey(od => new {od.OrderId});

            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Order>().HasKey(o => new {o.Id});
           
            
           


    } */


}