using UnityEngine;
using System.Collections;
using Shapeshift.Source.Util;
using System.Collections.Generic;
using Shapeshift.Source.Models.Jobs;

namespace Shapeshift.Source {
	
	public static class GameManager {

		public static List<GameObject> TreeObjects = new List<GameObject>();
		public static UniqueQueue<IJob> QueuedJobs = new UniqueQueue<IJob>();
		public static SelectedMode SelectedMode { get; set; }

		public static void AddInstalledObject(GameObject obj) {
			switch (obj.name) {
				case "Tree":
					obj.name += "_" + TreeObjects.Count;
					TreeObjects.Add(obj);
					break;
			}
		}
	}

	public enum SelectedMode {
		None,
		ChopTree
	}
}
