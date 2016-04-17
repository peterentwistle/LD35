using System;

namespace Shapeshift.Source.Models.InteractableObjects {
	
	public class InteractableObjectFactory {

		public InteractableObject CreateInteractableObject(InteractableType type, Tile tile) {

			InteractableObject obj = null;

			switch (type) {
				case InteractableType.Tree:
					obj = new TreeObject(tile);
					break;
				case InteractableType.Wall:
					obj = new WallObject(tile);
					break;
				case InteractableType.Meal:
					obj = new MealObject(tile);
					break;
				case InteractableType.Wood:
				obj = new WoodObject(tile);
					break;
			}

			return obj;
		}

	}
}
