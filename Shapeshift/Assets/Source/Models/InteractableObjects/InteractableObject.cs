using System;
using Shapeshift.Source.Models.Resources;

namespace Shapeshift.Source.Models.InteractableObjects {

	public class InteractableObject : IInteractable {

		public InteractableType InteractableType { get; private set; }
		public string Name { get; private set; }
		public bool Installed { get; private set; }
		public int Condition { get; private set; }
		public Resource Resource { get; private set; }
		public bool Destroyable { get; set; }
		public Tile Tile { get; private set; }

		public InteractableObject(InteractableType type, string name, Tile tile, bool installed = false, Resource resource = null, bool destroyable = true) {
			InteractableType = type;
			Name = name;
			Tile = tile;
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
