using System;
using UnityEngine;

namespace Shapeshift.Source.Models.Jobs {
	
	public class JobFactory {

		public IJob CreateJob(JobTypes jobType, GameObject gameObject, Tile tile) {

			IJob job = null;

			switch (jobType) {
				case JobTypes.Idle:
					job = new IdleJob();
					break;
				case JobTypes.ChopTree:
					job = new ChopTreeJob(gameObject, tile);
					break;
				case JobTypes.BuildWall:
					job = new BuildWallJob(gameObject, tile);
					break;
			}

			return job;
		}
	}
}

