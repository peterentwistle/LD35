using System;

namespace Shapeshift.Source.Models.InteractableObjects {

	public class MealObject : InteractableObject {

		public MealObject(Tile tile) : base(InteractableType.Meal, "Meal", tile) {
		}

	}

}

