using UnityEngine;
using System.Collections;
using Shapeshift.Source.Models;
using Shapeshift.Source.Models.InteractableObjects;

namespace Shapeshift.Source.Controllers {
	
	public class WorldController : MonoBehaviour {

		private World _world;
		public GameObject GroundTile;
		public Sprite DefaultSprite;

		void Start () {
			_world = new World(50, 50);

			for (int x = 0; x < World.Width; x++) {
				for (int y = 0; y < World.Height; y++) {
					Tile tile = _world.GetTileAt(x, y);

					var randObj = PlaceRandomObject();
					var location = new Vector3(tile.X, tile.Y, 0);

					if (randObj != null) {
						tile.PlacedObject = (GameObject) Instantiate(Resources.Load("Prefabs/PlacedObject"));
						tile.PlacedObject.GetComponent<PlacedObjectController>().PlacedObject = randObj;

						tile.PlacedObject.name = randObj.Name;
						tile.PlacedObject.transform.position = location;

						SpriteRenderer placedObjectSpriteRenderer = tile.PlacedObject.AddComponent<SpriteRenderer>();
						tile.PlacedObject.AddComponent<BoxCollider2D>();
						placedObjectSpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/"+tile.PlacedObject.name);
					}

					GameObject tileGameObj = Instantiate(GroundTile);
					tileGameObj.name = "Tile_X_"+x+"_Y_"+y;
					tileGameObj.transform.position = location;

					SpriteRenderer tileSpriteRenderer = tileGameObj.AddComponent<SpriteRenderer>();
					tileGameObj.AddComponent<BoxCollider2D>();

					tileSpriteRenderer.sprite = DefaultSprite;
				}
			}
		}

		private InteractableObject PlaceRandomObject() {
			var rand = Random.Range(0, 10);
			var factory = new InteractableObjectFactory();

			if (rand % 3 == 0) {
				return factory.CreateInteractableObject(InteractableType.Tree);
			}

			return null;
		}

	}

}