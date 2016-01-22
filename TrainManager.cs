using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrainManager : MonoBehaviour {

	GameObject trainFolder;
	int num_trains;
	public List<Train> trains;
	int[,] start_tiles;
	int[] start_directions;

	public int num_tiles_w;
	public int num_tiles_h;
	public int n;

	public GameManager owner;

	// Use this for initialization
	public void init (GameManager owner) {	
		this.owner = owner;
		this.num_tiles_w = owner.num_tiles_w;
		this.num_tiles_h = owner.num_tiles_h;
		this.num_trains = owner.num_trains;
		this.n = owner.n;

		start_tiles = new int[4,2] {
			{0, 0},
			{num_tiles_h - 1, 0},
			{0, num_tiles_w - 1},
			{num_tiles_h - 1, num_tiles_w - 1}
		};

		// Starting orientations
		start_directions = new int[4] {0, 1, 3, 2};

		trainFolder = new GameObject ();
		trainFolder.name = "Trains";

		for (int i = 0; i < num_trains; i++) {
			addTrain (i);
		}
	}

	void addTrain(int i){
		GameObject trainObject = new GameObject();
		trainObject.name = "Train " + i;
		Train new_train = trainObject.AddComponent<Train> ();
		new_train.transform.parent = trainFolder.transform;
		new_train.init (start_tiles[i, 0], start_tiles[i,1], start_directions [i], this);
	}

	public int getTileOrientation(int i, int j){
		return owner.getTileOrientation (i, j);
	}
}
