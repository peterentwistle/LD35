//  Copyright (c) 2016 Peter Entwistle
//
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//  SOFTWARE.

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
