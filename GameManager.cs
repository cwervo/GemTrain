/* GameManager.cs
 * High level game logic
 * John Burnett, Andres Cuervo, Sage Jenson
 * Gem Train
 * 2015-01-17
 * 
 * TODO:
 * -Movement
 X -Lock down tiles
 X -Gem collection
 X -Train collisions
 X -Scoreboard
 X -Fix horizontal spacing
 X -Gem lifespan
 */

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Board board;
	GemManager gems;
	TrainManager trains;
	float pr_switch = .1f;
	int score; 

	public int num_tiles_h = 10;
	public int num_tiles_w = 10;
	public int num_gems = 10;
	public int num_trains = 4; // num_trains = [0..4]
	public int n = 200; // maximum of t
	public int t = 0;  // time step

	// Use this for initialization
	void Start () {
		initialize ();
	}

	void initialize(){
		//		Screen.SetResolution (500, 500, true); // for John's weird screen
		board = gameObject.AddComponent<Board> ();
		board.init (num_tiles_w, num_tiles_h, pr_switch);

		gems = gameObject.AddComponent<GemManager> ();
		gems.init (num_tiles_w, num_tiles_h);
		makeGems ();

		trains = gameObject.AddComponent<TrainManager> ();
		trains.init (this);

		score = 0;
	}

	// Run every frame
	void Update () {

		frame ();

	}

	//run one frame of gameplay
	void frame(){
		t = (t + 1) % n;
		checkCollisions ();
		interaction ();
		checkGems ();
		addGems ();
	}

	void checkCollisions(){
		for (int i = 0; i < trains.trains.Count; i++) {
			int[] t1 = trains.trains [i].current_tile.getPos();
			for (int j = i + 1; j < trains.trains.Count; j++) {
				int[] t2 = trains.trains [j].current_tile.getPos();

				if (t1 [0] == t2 [0] && t1 [0] == t2 [0]) {
					trainsCollide (t1);
					return;
				}
			}
		}
	}

	void trainsCollide(int[] coords){
		print ("You done fucked. Some trains bashed.");
		initialize ();
	}
		
	//if gems have been collected, add more
	void addGems(){
		while (gems.gems.Count < num_gems) {
			gems.addGem ();
		}
	}

	// Check if the player is rotating a switch
	void interaction(){
		if (Input.GetMouseButtonDown (0)) {
			int mouseX = (int) Input.mousePosition.x;
			int mouseY = (int) Input.mousePosition.y;
			int[] pos = whichTile (mouseX, mouseY);
			bool lockTile = checkTrains (pos);
			if (!lockTile) {
				if ((pos [0] >= 0 && pos [0] < num_tiles_h) && (pos [1] >= 0 && pos [1] < num_tiles_w)) {
					board.rotate (pos [0], pos [1]);
				} else {
					print ("Click out of range");
				}
			}
		}
	}

	void checkGems(){
		foreach (Train t in trains.trains) {
			int[] train_coord = t.current_tile.getPos ();
			foreach (Gem g in gems.gems) {
				int[] gem_coord  = g.getCoordinants ();
				if (train_coord [0] == gem_coord [0] && train_coord [1] == gem_coord [1]) {
					gems.removeGem (gem_coord);
					score++;
				}
			}
		}
	}

	//check if there is a train at the current position
	bool checkTrains(int[] pos){
		foreach (Train t in trains.trains) {
			int[] train_coord = t.current_tile.getPos();
			if (train_coord [0] == pos [0] && train_coord [1] == pos [1]) {
				return true;
			}
		}
		return false;
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
		for (int i = 0; i < num_gems; i++) {
			gems.addGem ();
		}
	}

	public int getTileOrientation(int i, int j){
		return board.getTileOrientation (i, j);
	}
}
