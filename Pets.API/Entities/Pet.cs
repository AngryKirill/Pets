using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.API.Entities
{
    public class Pet
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public int Weight { get; set; }
	}
}
