using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Shapeshift.Source.Models;
using Shapeshift.Source.Models.InteractableObjects;

namespace Shapeshift.Source.Controllers {
	
	public class WorldController : MonoBehaviour {

		private World _world;

		public List<GameObject> Players { get; private set; }
		public GameObject GroundTile;
		public Sprite DefaultSprite;

		void Start () {
			generateWorld(50, 50);
			spawnPlayers();
		}

		private InteractableObject spawnRandomObjectAtTile(Tile tile) {
			var rand = Random.Range(0, 10);
			var factory = new InteractableObjectFactory();

			if (rand % 3 == 0) {
				return factory.CreateInteractableObject(InteractableType.Tree, tile);
			}

			return null;
		}

		private void placeRandomObjectOnTile(Tile tile) {
			var location = Tile.ToVector(tile);
			var randObj = spawnRandomObjectAtTile(tile);

			if (randObj != null) {
				tile.PlacedObject = (GameObject) Instantiate(Resources.Load("Prefabs/PlacedObject"));
				tile.PlacedObject.GetComponent<PlacedObjectController>().PlacedObject = randObj;

				tile.PlacedObject.name = randObj.Name;
				tile.PlacedObject.transform.position = location;

				SpriteRenderer placedObjectSpriteRenderer = tile.PlacedObject.AddComponent<SpriteRenderer>();
				placedObjectSpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/"+tile.PlacedObject.name);

				BoxCollider2D placedObjectCollider = tile.PlacedObject.AddComponent<BoxCollider2D>();
				placedObjectCollider.isTrigger = true;

				// Add to GameManager
				GameManager.AddInstalledObject(tile.PlacedObject);
			}
		}

		private void generateWorld(int width, int height) {
			_world = new World(width, height);

			for (int x = 0; x < World.Width; x++) {
				for (int y = 0; y < World.Height; y++) {
					Tile tile = _world.GetTileAt(x, y);
					var location = Tile.ToVector(tile);

					placeRandomObjectOnTile(tile);

					GameObject tileGameObj = Instantiate(GroundTile);
					tileGameObj.name = "Tile_X_"+x+"_Y_"+y;
					tileGameObj.transform.position = location;

					SpriteRenderer tileSpriteRenderer = tileGameObj.AddComponent<SpriteRenderer>();
					//tileGameObj.AddComponent<BoxCollider2D>(); Disabled collider

					tileSpriteRenderer.sprite = DefaultSprite;
				}
			}
		}

		private void spawnPlayers() {
			Players = new List<GameObject>();

			for (int i = 0; i < 3; i++) {
				Player player = new Player();
				GameObject playerGameObject = (GameObject) Instantiate(Resources.Load("Prefabs/Player"));
				playerGameObject.GetComponent<PlayerController>().Player = player;

				SpriteRenderer playerSpriteRenderer = playerGameObject.AddComponent<SpriteRenderer>();
				playerGameObject.AddComponent<BoxCollider2D>();
				playerSpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Player"+player.Gender.ToString());
				playerSpriteRenderer.sortingOrder = 1;

				playerGameObject.transform.position = new Vector3(World.Width / 2 + i, World.Height / 2, 0);
				Players.Add(playerGameObject);
			}
		}

	}
}