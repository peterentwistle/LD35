using System;
using Shapeshift.Source.Models.ResourceObjects;

namespace Shapeshift.Source.Models.InteractableObjects {

	public class InteractableObject : IInteractable {

		public InteractableType Type { get; private set; }
		public string Name { get; private set; }
		public bool Installed { get; private set; }
		public int Condition { get; private set; }
		public Resource Resource { get; private set; }
		public bool Destroyable { get; set; }

		public InteractableObject(InteractableType type, string name, bool installed = false, Resource resource = null, bool destroyable = true) {
			Type = type;
			Name = name;
			Installed = Installed;
			Resource = resource;
			Destroyable = destroyable;
		}

		public void UnInstall() {
			Installed = false;
		}
	}

	public enum InteractableType {
		Tree,
		Wall,
		Wood,
		Meal
	}
}
