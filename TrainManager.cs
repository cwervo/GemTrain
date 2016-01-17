using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrainManager : MonoBehaviour {

	GameObject trainFolder;
	int numTrains = 4;
	List<Train> trains;
	int num_tiles_w;
	int num_tiles_h;
	int[,] start_tiles;
	Vector2[] start_directions;

	// Use this for initialization
	public void init (int numTrains, int num_tiles_w, int num_tiles_h) {	
		this.num_tiles_w = num_tiles_w;
		this.num_tiles_h = num_tiles_h;

		start_tiles = new int[4,2] {
			{0, 0},
			{0, num_tiles_h},
			{num_tiles_w, 0},
			{num_tiles_w, num_tiles_h}
		};

		start_directions = new Vector2[4] {
			Vector2.up,
			Vector2.right,
			Vector2.down,
			Vector2.left
		};

		this.numTrains = numTrains;
		trainFolder = new GameObject ();
		trainFolder.name = "Trains";

		for (int i = 0; i < numTrains; i++) {
			addTrain (i);
		}
	}

	void addTrain(int i){
		GameObject trainObject = new GameObject();
		Train new_train = trainObject.AddComponent<Train> ();
		new_train.transform.parent = trainFolder.transform;
		new_train.init (start_tiles[i, 0], start_tiles[i,1], start_directions [i], num_tiles_w, num_tiles_h);
	}
	
}
