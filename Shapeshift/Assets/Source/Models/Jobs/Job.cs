using System;
using UnityEngine;
using Shapeshift.Source.Models;

namespace Shapeshift.Source.Models.Jobs {
	
	public abstract class Job : IJob {
		
		public JobTypes JobType { get; private set; }
		public Tile JobTile { get; private set; }
		public int WorkRequired { get; protected set; }
		public GameObject GameObject { get; set; }

		public Job(JobTypes type = JobTypes.Idle, Tile tile = default(Tile), GameObject gameObject = default(GameObject)) {
			JobType = type;
			JobTile = tile;
			GameObject = gameObject;
			WorkRequired = 5;
		}
	}

	public enum JobTypes {
		Idle,
		ChopTree,
		BuildWall
	}

}

