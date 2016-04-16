using UnityEngine;

namespace Shapeshift.Source.Models {

	public class Tile {

		public int X { get; private set; }
		public int Y { get; private set; }
		public GameObject PlacedObject { get; set; }

		public Tile(int x, int y) {
			X = x;
			Y = y;
		}

	}
}