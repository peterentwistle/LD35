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

using UnityEngine;
using System.Linq;
using System.Collections;
using Shapeshift.Source.Util;
using System.Collections.Generic;
using Shapeshift.Source.Models.Jobs;
using Shapeshift.Source.Models.Resources;

namespace Shapeshift.Source {
	
	public static class GameManager {

		public static List<GameObject> TreeObjects = new List<GameObject>();
		public static UniqueQueue<IJob> QueuedJobs = new UniqueQueue<IJob>();
		public static SelectedMode SelectedMode { get; set; }

		public static HashSet<IResource> Resources = new HashSet<IResource>() {
			new WoodResource()
		};

		public static void AddInstalledObject(GameObject obj) {
			switch (obj.name) {
				case "Tree":
					obj.name += "_" + TreeObjects.Count;
					TreeObjects.Add(obj);
					break;
			}
		}

		public static IResource GetResource(ResourceType type) {
			return Resources.Where(x => x.ResourceType == type).FirstOrDefault();
		}
	}

	public enum SelectedMode {
		None,
		ChopTree
	}
}
