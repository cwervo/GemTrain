/* Gem.cs
 * Create a gem's logic
 * John Burnett, Andres Cuervo, Sage Jenson
 * Gem Train
 * 2015-01-17
 */

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

