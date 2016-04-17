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

		public Tile() {
			X = -1;
			Y = -1;
		}

		public static Vector3 ToVector(Tile tile) {
			return new Vector3(tile.X, tile.Y, 0);
		}

	}
}