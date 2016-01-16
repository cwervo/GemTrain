// Tom Wexler
// Example program to help you get started with your project.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GemManager : MonoBehaviour {
	
	GameObject gemFolder;	// This will be an empty game object used for organizing objects in the Hierarchy pane.
	List<Gem> gems;			// This list will hold the gem objects that are created.
	int gemType; 			// The next gem type to be created.
	int num_tiles_w;
	int num_tiles_h;
	int[,] gem_field;

	public void init(int w, int h){
		gemFolder = new GameObject();  
		gemFolder.name = "Gems";		// The name of a game object is visible in the hHerarchy pane.
		gems = new List<Gem>();
		num_tiles_w = w;
		num_tiles_h = h;
		gem_field = new int[num_tiles_h,num_tiles_w];
	}

	public void addGem() {
		GameObject gemObject = new GameObject();			// Create a new empty game object that will hold a gem.
		Gem gem = gemObject.AddComponent<Gem>();			// Add the Gem.cs script to the object.
		gem.transform.parent = gemFolder.transform;			// Set the gem's parent object to be the gem folder.

		int x, y;
		do {
			x = Random.Range (0, num_tiles_w);
			y = Random.Range (0, num_tiles_h);
		} while (gem_field [y, x] == 1);

		gem_field [y, x] = 1;

		gem.init (x, y, num_tiles_w, num_tiles_h);

		gems.Add(gem);										// Add the gem to the Gems list for future access.
		gem.name = "Gem "+gems.Count;						// Give the gem object a name in the Hierarchy pane.
	}

}