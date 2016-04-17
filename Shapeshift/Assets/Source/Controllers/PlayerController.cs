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
			if (Player.CurrentJob.JobType != JobTypes.Idle)
				return;
			
			if (GameManager.QueuedJobs.Count == 0)
				return;
			
			Player.CurrentJob = GameManager.QueuedJobs.Dequeue();
		}

		public void ExecuteJob() {
			var job = Player.CurrentJob;

			if (!Player.JobComplete)
				return;

			if (job.JobType == JobTypes.Idle)
				return;
			
			if (job.JobType == JobTypes.ChopTree) {
				var targetPosition = new Vector3(Player.CurrentJob.JobTile.X, Player.CurrentJob.JobTile.Y, 0);

				WalkToTile(job.JobTile);
				if (transform.position == targetPosition) {
					Player.JobComplete = false;
					Invoke("TreeChopComplete", job.WorkRequired);
				}
			}
			
		}

		public void WalkToTile(Tile tile) {
			var targetPosition = new Vector3(tile.X, tile.Y, 0);
			transform.position = Vector3.MoveTowards(transform.position, targetPosition, Player.MovementSpeed * Time.deltaTime);
		}

		public void TreeChopComplete() {
			var job = Player.CurrentJob;
			SetPlayerJobToIdle();

			Destroy(job.GameObject);
			Player.JobComplete = true;
		}

		public void SetPlayerJobToIdle() {
			var jobFactory = new JobFactory();
			Player.CurrentJob = jobFactory.CreateJob(JobTypes.Idle, null, null);
		}
			
	}
}