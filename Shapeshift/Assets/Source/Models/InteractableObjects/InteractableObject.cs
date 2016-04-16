using System;

namespace Shapeshift.Source.Models.InteractableObjects {

	public class InteractableObject : IInteractable {

		public string Type { get; set; }
		public string Name { get; set; }
		public bool Installed { get; set; }
		
		public InteractableObject() {
			
		}

		public void UnInstall() {
		}
	}
}

