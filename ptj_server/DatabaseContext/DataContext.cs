using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using ptj_server.ModelConfigurations;
using ptj_server.Models;
using ptj_server.ViewModels;

namespace ptj_server.DatabaseContext
{
	public class DataContext:DbContext
	{
		public DataContext(){}
		public DataContext(DbContextOptions<DataContext> options):base(options) {}
		
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			
			builder.ApplyConfiguration(new GeomancyConfiguration());
			builder.ApplyConfiguration(new RoleConfiguration());
			builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new CustomerTypeConfiguration());
            builder.ApplyConfiguration(new StoneTypeConfiguration());
            builder.ApplyConfiguration(new ProductPriceConfiguration());
            builder.ApplyConfiguration(new CategoryProductConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ImageConfiguration());
            builder.ApplyConfiguration(new ProductDiscountConfiguration());
            builder.ApplyConfiguration(new PromotionConfiguration());
            builder.ApplyConfiguration(new PromotionDetailConfiguration());
            builder.ApplyConfiguration(new ProductDetailConfiguration());
            builder.ApplyConfiguration(new ReviewConfiguration());
            builder.ApplyConfiguration(new OrderProductConfiguration());
            builder.ApplyConfiguration(new OrderDetailConfiguration());
            builder.ApplyConfiguration(new CartConfiguration());

            // Config for VIEWMODEL

            // PRODUCT VIEW MODEL
            builder.Entity<ProductViewModel>(entity =>
            {
                entity.HasNoKey();
            });
        }
		
		public virtual DbSet<Geomancy> Geomancies { get; set; }
		public virtual DbSet<Role> Roles { get; set; }
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerType> CustomerTypes { get; set; }
        public virtual DbSet<ProductPrice> ProductPrices { get; set; }
        public virtual DbSet<CategoryProduct> CategoryProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<PromotionDetail> PromotionDetails { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }

        // Mapping for VIEWMODEL
        public virtual DbSet<ProductViewModel> ProductViewModels { get; set; }
    }
}

