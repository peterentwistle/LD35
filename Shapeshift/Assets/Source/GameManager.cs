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
