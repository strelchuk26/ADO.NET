using Microsoft.EntityFrameworkCore;
using shop_fluent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_fluent
{
	internal class ShopDbContext : DbContext
	{
		public ShopDbContext()
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<City>().HasOne(x => x.Country).WithMany(x => x.Cities).HasForeignKey(x => x.CountryId);
			modelBuilder.Entity<City>().HasMany(x => x.Shops).WithOne(x => x.City).HasForeignKey(x => x.CityId);
			modelBuilder.Entity<Shop>().HasMany(x => x.Products).WithMany(x => x.Shops);
			modelBuilder.Entity<Shop>().HasMany(x => x.Workers).WithOne(x => x.Shop).HasForeignKey(x => x.ShopId);
			modelBuilder.Entity<Product>().HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId).IsRequired(false);
			modelBuilder.Entity<Worker>().HasOne(x => x.Position).WithMany(x => x.Workers).HasForeignKey(x => x.PositionId);

			modelBuilder.Entity<Country>().HasData(new[]
			{
				new Country() { Id = 1, Name = "Ukraine"},
				new Country() { Id = 2, Name = "France"},
				new Country() { Id = 3, Name = "Spain"},
				new Country() { Id = 4, Name = "Germany"},
				new Country() { Id = 5, Name = "Italy"},
				new Country() { Id = 6, Name = "USA"},
				new Country() { Id = 7, Name = "England"},
				new Country() { Id = 8, Name = "Turkey"},
				new Country() { Id = 9, Name = "Poland"},
				new Country() { Id = 10, Name = "Austria"}
			});

			modelBuilder.Entity<City>().HasData(new[]
			{
				new City() { Id = 1, Name = "Kyiv", CountryId = 1},
				new City() { Id = 2, Name = "Paris", CountryId = 2},
				new City() { Id = 3, Name = "Madrid", CountryId = 3},
				new City() { Id = 4, Name = "Berlin", CountryId = 4},
				new City() { Id = 5, Name = "Rome", CountryId = 5},
				new City() { Id = 6, Name = "Washington", CountryId = 6},
				new City() { Id = 7, Name = "London", CountryId = 7},
				new City() { Id = 8, Name = "Istanbul", CountryId = 8},
				new City() { Id = 9, Name = "Warsav", CountryId = 9},
				new City() { Id = 10, Name = "Vienna", CountryId = 10}
			});

			modelBuilder.Entity<Category>().HasData(new[]
			{
				new Category() { Id = 1, Name = "Clothes"},
				new Category() { Id = 2, Name = "Food"},
				new Category() { Id = 3, Name = "Furniture"},
				new Category() { Id = 4, Name = "Cosmetic"},
				new Category() { Id = 5, Name = "Electronics"},
				new Category() { Id = 6, Name = "Jewelry"},
				new Category() { Id = 7, Name = "Household appliances"}
			});

			modelBuilder.Entity<Position>().HasData(new[]
			{
				new Position() { Id = 1, Name = "Manager"},
				new Position() { Id = 2, Name = "Head"},
				new Position() { Id = 3, Name = "Cashier"},
				new Position() { Id = 4, Name = "Seller-consultant"},
				new Position() { Id = 5, Name = "Guardian"},
				new Position() { Id = 6, Name = "Cleaner"}
			});

			modelBuilder.Entity<Shop>().HasData(new[]
			{ 
				new Shop()
				{
					Id = 1,
					Name = "Silpo",
					Address = "Kyivska 69",
					CityId = 1,
					ParkingArea = 2
				}
			});

			modelBuilder.Entity<Product>().HasData(new[]
			{ 
				new Product()
				{ 
					Id = 1,
					Name = "Play Station 5",
					Price = (decimal)25.500,
					Discount = 5.0F,
					CategoryId = 5,
					Quantity = 1,
					IsInStock = true
				}
			});
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ShopFluentDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<Position> Positions { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Shop> Shops { get; set; }
		public DbSet<Worker> Workers { get; set; }
	}
}
