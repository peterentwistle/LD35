using System;
using UnityEngine;

namespace Shapeshift.Source.Models.Jobs {

	public class BuildWallJob : Job, IJob {

		public BuildWallJob(GameObject wallGameObject, Tile tile) : base(JobTypes.BuildWall, tile, wallGameObject) {
		}
	}
}

