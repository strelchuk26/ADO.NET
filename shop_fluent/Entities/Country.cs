﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_fluent.Entities
{
	internal class Country
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<City> Cities { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}
