using UnityEngine;
using System.Collections;
using Shapeshift.Source.Models;
using Shapeshift.Source.Models.Jobs;

namespace Shapeshift.Source.Controllers {

	public class PlayerController : MonoBehaviour {

		public Player Player { get; set; }

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			PickupJob();
			ExecuteJob();
		}

		public void PickupJob() {
			if (Player.CurrentJob.Type != JobTypes.Idle)
				return;
			
			if (GameManager.QueuedJobs.Count == 0)
				return;
			
			Player.CurrentJob = GameManager.QueuedJobs.Dequeue();
		}

		public void ExecuteJob() {
			var job = Player.CurrentJob;

			if (job.Type == JobTypes.Idle)
				return;
			
			if (job.Type == JobTypes.ChopTree) {
				WalkToTile(job.JobTile);
			}
			
		}

		public void WalkToTile(Tile tile) {
			var targetPosition = new Vector3(tile.X, tile.Y, 0);
			transform.position = Vector3.MoveTowards(transform.position, targetPosition, Player.MovementSpeed * Time.deltaTime);
		}
			
	}
}