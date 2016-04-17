using UnityEngine;
using System.Collections;
using Shapeshift.Source.Models.InteractableObjects;
using Shapeshift.Source.Models.Jobs;

namespace Shapeshift.Source.Controllers {

	public class PlacedObjectController : MonoBehaviour {

		public InteractableObject PlacedObject { get; set; }
	
		void OnMouseUp() {
			if (GameManager.SelectedMode == SelectedMode.ChopTree) {
				GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/TreeChop");
				GameManager.QueuedJobs.Enqueue(new ChopTreeJob(gameObject));
			}
		}

	}
}