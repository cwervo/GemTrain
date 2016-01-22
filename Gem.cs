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
	private int gem_type;		// Will determine the color and animation for the model.
	int num_tiles_w;
	int num_tiles_h;
	int screen_x, screen_y;
	int[] coordinants;

	// The Start function is good for initializing objects, but doesn't allow you to pass in parameters.
	// For any initialization that requires input, you'll probably want your own init function. 

	public void init(int x, int y, GemManager owner) {
		num_tiles_w = owner.num_tiles_w;
		num_tiles_h = owner.num_tiles_h;

		coordinants = new int[] {x, y};
		float[] pos = position (x, y);
		screen_x = (int) pos [0];
		screen_y = (int) pos [1];
		this.transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (screen_x, screen_y, 9));

		var modelObject = GameObject.CreatePrimitive(PrimitiveType.Quad);	// Create a quad object for holding the gem texture.
		model = modelObject.AddComponent<GemModel>();						// Add a gem_model script to control visuals of the gem.
		model.init(this);
	}

	float[] position(int i, int j){
		float x = (Screen.width / num_tiles_w) * (float) i + Screen.width / (num_tiles_w * 2);
		float y = (Screen.height / num_tiles_h) * (float) j + Screen.height / (num_tiles_h * 2);
		float[] returnMe  =  {x, y};
		return returnMe;
	}

	public int[] getCoordinants(){
		return coordinants;
	}


}

