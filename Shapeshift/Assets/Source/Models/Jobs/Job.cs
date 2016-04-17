using System;
using Shapeshift.Source.Models;

namespace Shapeshift.Source.Models.Jobs {
	
	public class Job {

		public JobTypes Type { get; private set; }
		public Tile JobTile { get; private set; }

		public Job(JobTypes type = JobTypes.Idle, Tile tile = default(Tile)) {
			Type = type;
			JobTile = tile;
		}
	}

	public enum JobTypes {
		Idle,
		ChopTree,
		BuildWall
	}

}

