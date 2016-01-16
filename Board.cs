using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board : MonoBehaviour {

	GameObject tileFolder;	// This will be an empty game object used for organizing objects in the Hierarchy pane.
	List<List<Tile>> tiles;	// This list will hold the gem objects that are created.

	int num_tiles_h = 10;
	int num_tiles_w = 18;

	void Start () {
		tileFolder = new GameObject();
		tileFolder.name = "Board";
		tiles = new List<List<Tile>>();
		for (int i = 0; i < num_tiles_h; i++) {
			tiles.Add(new List<Tile>());
		}
		newBoard ();
	}

	void newBoard() {
		for (int i = 0; i < num_tiles_h; i++) {
			tiles [i].Clear();
		}

		for (int i = 0; i < num_tiles_h; i++) {
			for (int j = 0; j < num_tiles_w; j++) {
				addTile (i, j);
			}
		}
	}

	void addTile(int i, int j) {
		int tile_type = Random.Range (0, 2);

		GameObject tileObject = new GameObject();			// Create a new empty game object that will hold a gem.
		Tile new_tile = tileObject.AddComponent<Tile>();			// Add the Gem.cs script to the object.
		new_tile.transform.parent = tileFolder.transform;
		new_tile.init (tile_type);

		tiles [i].Add (new_tile);
		int[] pos = { i, j };
		tiles [i][j].pos = pos;
		float x = Screen.width / num_tiles_w * (float) j + Screen.width/(num_tiles_w*2);
		float y = Screen.height / num_tiles_h * (float) i + Screen.height/(num_tiles_h*2);
		tiles [i][j].transform.position = Camera.main.ScreenToWorldPoint( new Vector3 (x, y, 10) );
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			int mouseX = (int) Input.mousePosition.x;
			int mouseY = (int) Input.mousePosition.y;
			print(mouseX + ", " + mouseY);
			int[] pos = whichTile (mouseX, mouseY);
			tiles [pos[0]] [pos[1]].rotate ();
		}
	}

	int[] whichTile(int x, int y) {
//		x += Screen.width / (num_tiles_w * 2);
//		y += Screen.height / (num_tiles_h * 2);
		int i = (int) System.Math.Floor((double) y / (Screen.height / num_tiles_h));
		int j = (int) System.Math.Floor((double) x / (Screen.width / num_tiles_w));
		print (i + ", " + j);
		int[] pos = { i, j };
		return pos;
	}

	void OnGUI () {

	}
}
