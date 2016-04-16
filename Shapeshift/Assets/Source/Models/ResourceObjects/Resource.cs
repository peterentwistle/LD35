using System;

namespace Shapeshift.Source.Models.ResourceObjects {

	public class Resource {

		public int Quantity { get; set; }
		public bool Edible { get; set; }

		public Resource(int quantity, bool edible = false) {
			Quantity = quantity;
			Edible = edible;
		}
	}

	public enum ResourceType {
		Wood,
		Meal
	}
}

