/* GameManager.cs
 * High level game logic
 * John Burnett, Andres Cuervo, Sage Jenson
 * Gem Train
 * 2015-01-17
 */

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	Board board;
	GemManager gems;
	TrainManager trains;
	int num_tiles_h = 10;
	int num_tiles_w = 18;
	float prSwitch = .1f;

	int numGems = 50;

	// Use this for initialization
	void Start () {
		board = gameObject.AddComponent<Board>();
		board.init (num_tiles_w, num_tiles_h, prSwitch);

		gems = gameObject.AddComponent<GemManager>();
		gems.init (num_tiles_w, num_tiles_h);
		makeGems ();

		trains = gameObject.AddComponent<TrainManager>();
		trains.init (4, num_tiles_w, num_tiles_h);
	}

	// Run every frame
	void Update () {
		interaction ();
	}

	// Check if the player is rotating a switch
	void interaction(){
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

	// Return the simplified coordinants of a player's click (where the click is located on the board)
	int[] whichTile(int x, int y) {
		int i = (int) System.Math.Floor((double) y / (Screen.height / num_tiles_h));
		int j = (int) System.Math.Floor((double) x / (Screen.width / num_tiles_w));
		int[] pos = { i, j };
		return pos;
	}

	// Splay ye's gems 'cross thoust's turbid board
	void makeGems(){
		for (int i = 0; i < numGems; i++) {
			gems.addGem ();
		}
	}
}
