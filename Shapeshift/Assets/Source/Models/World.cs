using System;

namespace Shapeshift.Source.Models {
	
	public class World {

		private Tile[,] _tiles;
		public static int Width { get; private set; }
		public static int Height { get; private set; }

		public World(int width, int height) {
			Width = width;
			Height = height;
			instantiateTiles();
		}

		public Tile GetTileAt(int x, int y) {
			return _tiles[x, y];
		}

		private void instantiateTiles() {
			_tiles = new Tile[Width, Height];

			for (int x = 0; x < Width; x++) {
				for (int y = 0; y < Height; y++) {
					_tiles[x, y] = new Tile(x, y);
				}
			}
		}

	}
}
