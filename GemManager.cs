// Tom Wexler
// Example program to help you get started with your project.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GemManager : MonoBehaviour {
	
	GameObject gemFolder;	// This will be an empty game object used for organizing objects in the Hierarchy pane.
	List<Gem> gems;			// This list will hold the gem objects that are created.
	int gemType; 			// The next gem type to be created.
	
	// Start is called once when the script is created.
	void Start () {
		gemFolder = new GameObject();  
		gemFolder.name = "Gems";		// The name of a game object is visible in the hHerarchy pane.
		gems = new List<Gem>();
		gemType = 1;
	}

	// Update is called every frame.
	void Update () {
		if (Input.GetMouseButtonUp(0)) { // If the user releases the left mouse button, figure out where the mouse is and spawn a gem.
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 	// Convert mouse's screen position to world position.
			float mouseX = worldPos.x;
			float mouseY = worldPos.y;
			print("you just clicked at "+mouseX+" "+mouseY);
			addGem(mouseX, mouseY);
		}
	}

	void addGem(float x, float y) {
		GameObject gemObject = new GameObject();			// Create a new empty game object that will hold a gem.
		Gem gem = gemObject.AddComponent<Gem>();			// Add the Gem.cs script to the object.
															// We can now refer to the object via this script.
		gem.transform.parent = gemFolder.transform;			// Set the gem's parent object to be the gem folder.
		gem.transform.position = new Vector3(x,y,0);		// Position the gem at x,y.								
		
		gem.init(gemType, this);							// Initialize the gem script.
		
		gems.Add(gem);										// Add the gem to the Gems list for future access.
		gem.name = "Gem "+gems.Count;						// Give the gem object a name in the Hierarchy pane.
		
		gemType = (gemType%4) + 1;							
	}

	// This function defines the buttons, and dictates what happens when they're pressed.
	void OnGUI () {
		if (GUI.Button (new Rect (10,400,100,30), "Self Destruct")) 
			print("omg you pressed a button"); 
			// Printing goes to the Console pane.  
			// If an object doesn't extend monobehavior, calling print won't do anything.  
			// Make sure "Collapse" isn't selected in the Console pane if you want to see duplicate messages.
	}

}