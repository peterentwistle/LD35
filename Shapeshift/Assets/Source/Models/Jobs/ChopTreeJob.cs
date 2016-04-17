using System;
using UnityEngine;

namespace Shapeshift.Source.Models.Jobs {

	public class ChopTreeJob : Job {

		public GameObject Tree;

		public ChopTreeJob(GameObject tree, Tile tile) : base(JobTypes.ChopTree, tile) {
			Tree = tree;
		}
	}
}
