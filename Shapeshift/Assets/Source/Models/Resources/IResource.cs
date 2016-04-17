using System;

namespace Shapeshift.Source.Models.Resources {

	public interface IResource {
		int Quantity { get; }
		bool Edible { get; }
		ResourceType ResourceType { get; }

		void Add(int quantity);
		void Subtract(int quantity);
	}
}
