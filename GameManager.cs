using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	Board board;
	GemManager gems;
	int num_tiles_h = 10;
	int num_tiles_w = 18;

	int numGems = 50;

	// Use this for initialization
	void Start () {
		board = new Board ();
		board.init (num_tiles_w, num_tiles_h);

		gems = new GemManager ();
		gems.init (num_tiles_w, num_tiles_h);
		makeGems ();
	}
	
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			int mouseX = (int) Input.mousePosition.x;
			int mouseY = (int) Input.mousePosition.y;
			int[] pos = whichTile (mouseX, mouseY);
			if ((pos [0] >= 0 && pos [0] < num_tiles_h) && (pos [1] >= 0 && pos [1] < num_tiles_w)) {
				board.rotate (pos[0], pos[1]);
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

	void makeGems(){
		for (int i = 0; i < numGems; i++) {
			gems.addGem ();
		}
	}
}
