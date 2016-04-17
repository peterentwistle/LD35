using System;

namespace Shapeshift.Source.Models.Resources {

	public abstract class Resource : IResource {

		public int Quantity { get; protected set; }
		public bool Edible { get; protected set; }
		public ResourceType ResourceType { get; protected set; }

		public Resource(ResourceType type, int quantity = 0, bool edible = false) {
			ResourceType = type;
			Quantity = quantity;
			Edible = edible;
		}

		public void Add(int quantity) {
			Quantity += quantity;
		}

		public void Subtract(int quantity) {
			Quantity -= quantity;
		}
	}

	public enum ResourceType {
		Wood,
		Meal
	}

}