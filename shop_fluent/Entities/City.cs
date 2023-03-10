using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_fluent.Entities
{
	internal class City
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int CountryId { get; set; }
		public Country Country { get; set; }
		public ICollection<Shop> Shops { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}
