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
