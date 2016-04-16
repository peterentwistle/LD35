using System;

namespace Shapeshift.Source.Models.InteractableObjects {
	
	public class InteractableObjectFactory {

		public InteractableObject CreateInteractableObject(InteractableType type) {

			InteractableObject obj = null;

			switch (type) {
				case InteractableType.Tree:
					obj = new TreeObject();
					break;
				case InteractableType.Wall:
					obj = new WallObject();
					break;
				case InteractableType.Meal:
					obj = new MealObject();
					break;
				case InteractableType.Wood:
					obj = new WoodObject();
					break;
			}

			return obj;
		}

	}
}
