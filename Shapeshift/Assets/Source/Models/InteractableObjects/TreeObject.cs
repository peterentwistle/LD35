using System;

namespace Shapeshift.Source.Models.InteractableObjects {
	
	public class TreeObject : InteractableObject {

		public TreeObject(Tile tile) : base(InteractableType.Tree, "Tree", tile, true) {
		}
	}

}

