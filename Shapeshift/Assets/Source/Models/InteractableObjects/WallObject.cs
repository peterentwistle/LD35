using System;

namespace Shapeshift.Source.Models.InteractableObjects {

	public class WallObject : InteractableObject {

		public WallObject(Tile tile) : base(InteractableType.Wall, "Wall", tile, true){
		}

	}

}

