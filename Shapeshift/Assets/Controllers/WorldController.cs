using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour {

	private World _world;
	public GameObject GroundTile;
	public Sprite DefaultSprite;

	void Start () {
		_world = new World(20, 20);

		for (int x = 0; x < World.Width; x++) {
			for (int y = 0; y < World.Height; y++) {
				Tile tile = _world.GetTileAt(x, y);

				GameObject tileGameObj = Instantiate(GroundTile);
				tileGameObj.name = "Tile_X_"+x+"_Y_"+y;
				tileGameObj.transform.position = new Vector3(tile.X, tile.Y, 0);

				SpriteRenderer tileSpriteRenderer = tileGameObj.AddComponent<SpriteRenderer>();
				tileGameObj.AddComponent<BoxCollider2D>();

				tileSpriteRenderer.sprite = DefaultSprite;
			}
		}
	}

}
