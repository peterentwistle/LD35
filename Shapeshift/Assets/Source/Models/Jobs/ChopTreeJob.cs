using System;
using UnityEngine;

namespace Shapeshift.Source.Models.Jobs {

	public class ChopTreeJob : Job, IJob {

		public ChopTreeJob(GameObject treeGameObject, Tile tile) : base(JobTypes.ChopTree, tile, treeGameObject) {
			WorkRequired = 3;
		}
	}
}
