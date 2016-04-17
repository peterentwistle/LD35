using UnityEngine;
using System.Collections;
using Shapeshift.Source.Models;
using Shapeshift.Source.Models.Jobs;
using Shapeshift.Source.Models.Resources;

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
			pickupJob();
			executeJob();
		}

		private void pickupJob() {
			if (Player.CurrentJob.JobType != JobTypes.Idle)
				return;
			
			if (GameManager.QueuedJobs.Count == 0)
				return;
			
			Player.CurrentJob = GameManager.QueuedJobs.Dequeue();
		}

		private void executeJob() {
			var job = Player.CurrentJob;

			if (!Player.JobComplete)
				return;

			if (job.JobType == JobTypes.Idle) {
				wonder();
				return;
			}
			
			if (job.JobType == JobTypes.ChopTree) {
				chopTree();
				return;
			}
			
		}

		private void walkToTile(Tile tile) {
			var targetPosition = Tile.ToVector(tile);
			transform.position = Vector3.MoveTowards(transform.position, targetPosition, Player.MovementSpeed * Time.deltaTime);
		}

		private void chopTree() {
			var job = Player.CurrentJob;
			var targetPosition = Tile.ToVector(Player.CurrentJob.JobTile);

			walkToTile(job.JobTile);
			if (transform.position == targetPosition) {
				Player.JobComplete = false;
				Invoke("treeChopComplete", job.WorkRequired);
			}
		}

		private void setPlayerJobToIdle() {
			var jobFactory = new JobFactory();
			resetWonderTileLocations();
			Player.CurrentJob = jobFactory.CreateJob(JobTypes.Idle, null, null);
		}

		private void wonder() {
			if (Tile.ToVector(_walkToTile) != transform.position) {
				walkToTile(_walkToTile);
				return;
			}

			if (!_wondering) {
				var distance = Vector3.Distance(Tile.ToVector(_startTile), Tile.ToVector(CurrentTile));
				_wondering = true;

				if (distance > 3)
					_walkToTile = _startTile;
				else
					_walkToTile = new Tile(CurrentTile.X + Random.Range(-2, 2), CurrentTile.Y + Random.Range(-2, 2));
				
				Invoke("wonderComplete", Random.Range(2, 5));
			}
		}

		private void wonderComplete() {
			_wondering = false;
		}

		private void treeChopComplete() {
			var job = Player.CurrentJob;
			setPlayerJobToIdle();

			Destroy(job.GameObject);
			GameManager.GetResource(ResourceType.Wood).Add(4);
			Player.JobComplete = true;
		}

		private void resetWonderTileLocations() {
			_startTile = CurrentTile;
			_walkToTile = CurrentTile;
		}
	}

}