using UnityEngine;
using System.Collections;
using Shapeshift.Source.Models;
using Shapeshift.Source.Models.Jobs;

namespace Shapeshift.Source.Controllers {

	public class PlayerController : MonoBehaviour {

		private bool _wondering;
		private Tile _walkToTile;
		private Tile _startTile;
		public Player Player { get; set; }

		public Tile CurrentTile {
			get {
				return new Tile((int)transform.position.x, (int)transform.position.y);
			}
		}

		// Use this for initialization
		void Start () {
			_wondering = false;
			resetWonderTileLocations();
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

			if (job.JobType == JobTypes.Idle) {
				Wonder();
				return;
			}
			
			if (job.JobType == JobTypes.ChopTree) {
				ChopTree();
				return;
			}
			
		}

		public void WalkToTile(Tile tile) {
			var targetPosition = new Vector3(tile.X, tile.Y, 0);
			transform.position = Vector3.MoveTowards(transform.position, targetPosition, Player.MovementSpeed * Time.deltaTime);
		}

		public void ChopTree() {
			var job = Player.CurrentJob;
			var targetPosition = new Vector3(Player.CurrentJob.JobTile.X, Player.CurrentJob.JobTile.Y, 0);

			WalkToTile(job.JobTile);
			if (transform.position == targetPosition) {
				Player.JobComplete = false;
				Invoke("treeChopComplete", job.WorkRequired);
			}
		}

		public void SetPlayerJobToIdle() {
			var jobFactory = new JobFactory();
			resetWonderTileLocations();
			Player.CurrentJob = jobFactory.CreateJob(JobTypes.Idle, null, null);
		}

		public void Wonder() {
			if (!SameLocation(new Vector3(_walkToTile.X, _walkToTile.Y, 0), transform.position)) {
				WalkToTile(_walkToTile);
				return;
			}

			if (!_wondering) {
				var distance = Vector3.Distance(Tile.ToVector(_startTile), Tile.ToVector(CurrentTile));
				Debug.Log(string.Format("Distance from start: {0} Age: {1}", distance, Player.Age));
				_wondering = true;

				if (distance > 3)
					_walkToTile = _startTile;
				else
					_walkToTile = new Tile(CurrentTile.X + Random.Range(-2, 2), CurrentTile.Y + Random.Range(-2, 2));
				
				Invoke("wonderComplete", Random.Range(2, 5));
			}
		}

		public bool SameLocation(Vector3 l1, Vector3 l2) {
			return l1 == l2;
		}

		private void wonderComplete() {
			_wondering = false;
		}

		private void treeChopComplete() {
			var job = Player.CurrentJob;
			SetPlayerJobToIdle();

			Destroy(job.GameObject);
			Player.JobComplete = true;
		}

		private void resetWonderTileLocations() {
			_startTile = CurrentTile;
			_walkToTile = CurrentTile;
		}
	}

}