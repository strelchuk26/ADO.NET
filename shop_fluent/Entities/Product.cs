using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_fluent.Entities
{
	internal class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public float Discount { get; set; }
		public int? CategoryId { get; set; }
		public int Quantity { get; set; }
		public bool IsInStock { get; set; }
		public Category Category { get; set; }
		public ICollection<Shop> Shops { get; set; }

		public override string ToString()
		{
			return $"[{Id}] {Name} {Price} {Discount} {Category} {Quantity}";
		}
	}
}
