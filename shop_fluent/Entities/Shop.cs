using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_fluent.Entities
{
	internal class Shop
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public int CityId { get; set; }
		public int? ParkingArea { get; set; }
		public City City { get; set; }
		public ICollection<Worker> Workers { get; set; }
		public ICollection<Product> Products { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}
