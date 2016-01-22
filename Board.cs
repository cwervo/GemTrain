/* Board.cs
 * Create a new board
 * John Burnett, Andres Cuervo, Sage Jenson
 * Gem Train
 * 2015-01-17
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board : MonoBehaviour {

	GameObject tile_folder;
	public List<List<Tile>> tiles;

	int num_tiles_h;
	int num_tiles_w;
	float pr_switch;

	/* Custom initialization function 
	 * w and h are the number of tiles in the board
	 */
	public void init(int w, int h, float prob) {
		num_tiles_w = w;
		num_tiles_h = h;
		pr_switch = prob;
		tile_folder = new GameObject();
		tile_folder.name = "Board";
		tiles = new List<List<Tile>>();
		for (int i = 0; i < num_tiles_h; i++) {
			tiles.Add(new List<Tile>());
		}
		newBoard ();
	}

	// Create a new board
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

	// Create a new tile with a pr_switch probability of being a switch
	void addTile(int i, int j) {
		GameObject tileObject = new GameObject();
		Tile new_tile = tileObject.AddComponent<Tile>();
		new_tile.transform.parent = tile_folder.transform;

		float chance = Random.Range (0f, 1f);
		if (chance > pr_switch) {
			new_tile.init (0); // blank tile
		} else {
			new_tile.init (1); // turn tile
		}
		new_tile.name = "Tile";

		tiles [i].Add (new_tile);
		int[] pos = { i, j };
		tiles [i][j].pos = pos;
		float x = Screen.width / num_tiles_w * (float) j + Screen.width/(num_tiles_w*2);
		float y = Screen.height / num_tiles_h * (float) i + Screen.height/(num_tiles_h*2);
		tiles [i][j].transform.position = Camera.main.ScreenToWorldPoint( new Vector3 (x, y, 10) );

	}

	public void rotate(int i, int j){
		tiles [i] [j].rotate ();
	}

	public int getTileOrientation(int i, int j){
		return tiles [i] [j].getRot ();
	}

}
