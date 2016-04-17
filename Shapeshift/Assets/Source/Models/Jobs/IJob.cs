using System;
using UnityEngine;

namespace Shapeshift.Source.Models.Jobs {
	
	public interface IJob {
		JobTypes JobType { get; }
		Tile JobTile { get; }
		int WorkRequired { get; }
		GameObject GameObject { get; }
	}
}

