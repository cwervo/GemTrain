﻿/* GameManager.cs
 * High level game logic
 * John Burnett, Andres Cuervo, Sage Jenson
 * Gem Train
 * 2015-01-17
 * 
 * TODO:
 * -Movement
 * -Lock down tiles
 * -Gem collection
 * -Train collisions
 * -Scoreboard
 X -Fix horizontal spacing
 * -Gem regeneration, lifespan
 */

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Board board;
	GemManager gems;
	TrainManager trains;
	float pr_switch = .1f;

	public int num_tiles_h = 10;
	public int num_tiles_w = 10;
	public int num_gems = 50;
	public int num_trains = 1; // num_trains = [0..4]
	public int n = 200; // maximum of t
	public int t = 0;  // time step

	// Use this for initialization
	void Start () {
//		Screen.SetResolution (500, 500, true); // for John's weird screen
		board = gameObject.AddComponent<Board>();
		board.init (num_tiles_w, num_tiles_h, pr_switch);

		gems = gameObject.AddComponent<GemManager>();
		gems.init (num_tiles_w, num_tiles_h);
		makeGems ();

		trains = gameObject.AddComponent<TrainManager>();
		trains.init (this);
	}

	// Run every frame
	void Update () {
		interaction ();
		t = (t + 1) % n;
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
		for (int i = 0; i < num_gems; i++) {
			gems.addGem ();
		}
	}

	public int getTileOrientation(int i, int j){
		return board.getTileOrientation (i, j);
	}
}
