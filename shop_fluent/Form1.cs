using Microsoft.EntityFrameworkCore;
using shop_fluent.Entities;

namespace shop_fluent
{
	public partial class Form1 : Form
	{
		ShopDbContext db = new ShopDbContext();
		Shop selected_shop = new Shop();
		public Form1()
		{
			InitializeComponent();
		}

		private void showProductsButton_Click(object sender, EventArgs e)
		{
			if (selected_shop == null)
				return;

			shopItemsListBox.DataSource = null;
			List<Product> products = new List<Product>();

			foreach (var p in selected_shop.Products.ToList())
			{
				products.Add(new Product()
				{
					Id = p.Id,
					Name = p.Name,
					Price = p.Price,
					Discount = p.Discount,
					Category = p.Category,
					Quantity = p.Quantity,
					IsInStock = p.IsInStock
				});
			}

			shopItemsListBox.DataSource = products;
		}
		private void showWorkersButton_Click(object sender, EventArgs e)
		{
			if (selected_shop == null)
				return;

			shopItemsListBox.DataSource = null;
			List<Worker> workers = new List<Worker>();

			foreach (var w in selected_shop.Workers)
			{
				workers.Add(new Worker()
				{
					Id = w.Id,
					Name = w.Name,
					Surname = w.Surname,
					Salary = w.Salary,
					Email = w.Email,
					PhoneNumber = w.PhoneNumber,
					PositionId = w.PositionId,
					ShopId = w.ShopId
				});
			}

			shopItemsListBox.DataSource = workers;
		}

		private void refreshShopListButton_Click(object sender, EventArgs e)
		{
			shopsListBox.DataSource = db.Shops.ToList();
		}

		private void shopsListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (shopsListBox.SelectedItem == null)
				return;

			var shop = shopsListBox.SelectedItem as Shop;
			selected_shop = new Shop() 
			{
				Id = shop.Id,
				Name = shop.Name,
				Address = shop.Address,
				CityId = shop.CityId,
				ParkingArea = shop.ParkingArea,
				Products = shop.Products,
				Workers = shop.Workers
			};
		}

	}
}