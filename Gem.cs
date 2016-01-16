// Tom Wexler
// Gem class

// This script is attached to an empty object.  It doesn't do much beyond making a quad (a rectangle that can be
// given a texture), attaching a GemModel script to it, and initializing it.  

// Generally it's a good idea for any core game element to be an empty object with a script controlling 
// non-graphical features and logic of the object. For example, you might have an enemy class. The associated
// script would keep track of things like health and attack power, as well as specifying behavior. This object 
// would contain a child object that we refer to as the model. The model has it's own script and is
// in charge of visual aspects of this game element such as animation, scaling, lighting, etc. In a more 
// complicated example, the model might itself be an empty object with many children. E.g. an enemy class might
// have an object for the body, another for a weapon that can move independently, and another for a health meter.
// The game element object tells the model object that it wants to attack, or that it took damage, and the model 
// object updates appropriately. Separating logic and graphics in this way makes things easier to organize and 
// update. 

using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour {

	private GemModel model;		// The model object.
	private int gemType;		// Will determine the color and animation for the model.
	int num_tiles_w;
	int num_tiles_h;
	int screenX, screenY;

	// The Start function is good for initializing objects, but doesn't allow you to pass in parameters.
	// For any initialization that requires input, you'll probably want your own init function. 

	public void init(int x, int y, int w, int h) {
		num_tiles_h = h;
		num_tiles_w = w;

		float[] pos = position (x, y);
		screenX = (int) pos [0];
		screenY = (int) pos [1];
		this.transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (screenX, screenY, 9));

		var modelObject = GameObject.CreatePrimitive(PrimitiveType.Quad);	// Create a quad object for holding the gem texture.
		model = modelObject.AddComponent<GemModel>();						// Add a gemModel script to control visuals of the gem.
		model.init(this);
	}

	float[] position(int i, int j){
		float x = (Screen.width / num_tiles_w) * (float) i + Screen.width / (num_tiles_w * 2);
		float y = (Screen.height / num_tiles_h) * (float) j + Screen.height / (num_tiles_h * 2);
		float[] returnMe  =  {x, y};
		return returnMe;
	}
}

