using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board : MonoBehaviour {

	GameObject tileFolder;
	List<List<Tile>> tiles;

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
		GameObject tileObject = new GameObject();
		Tile new_tile = tileObject.AddComponent<Tile>();
		new_tile.transform.parent = tileFolder.transform;

		float chance = Random.Range (0f, 1f);
		if (chance < 0.8) {
			new_tile.init (0); // blank tile
		} else {
			new_tile.init (1); // turn tile
		}

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
			int[] pos = whichTile (mouseX, mouseY);
			if ((pos [0] >= 0 && pos [0] < num_tiles_h) && (pos [1] >= 0 && pos [1] < num_tiles_w)) {
				tiles [pos [0]] [pos [1]].rotate ();
			} else {
				print ("Click out of range");
			}
		}
	}

	int[] whichTile(int x, int y) {
		int i = (int) System.Math.Floor((double) y / (Screen.height / num_tiles_h));
		int j = (int) System.Math.Floor((double) x / (Screen.width / num_tiles_w));
		int[] pos = { i, j };
		return pos;
	}

	void OnGUI () {

	}
}
