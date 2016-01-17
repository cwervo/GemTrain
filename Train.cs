/* Train.cs
 * Train logic
 * John Burnett, Andres Cuervo, Sage Jenson
 * Gem Train
 * 2015-01-17
 */

using UnityEngine;
using System.Collections;

public class Train : MonoBehaviour {

	TrainModel model;
	int num_tiles_w;
	int num_tiles_h;
	int screenX, screenY;
	int orientation;
	Vector2 direction, location;
	float tileWidth;

	// Use this for initialization
	public void init(int i, int j, Vector2 start_dir, int num_tiles_w, int num_tiles_h){
		this.num_tiles_w = num_tiles_w;
		this.num_tiles_h = num_tiles_h;
		tileWidth = Screen.width / num_tiles_w;

		float[] pos = position (i, j);
		screenX = (int) pos [0];
		screenY = (int) pos [1];
		this.transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (screenX, screenY, 8));

		var modelObject = GameObject.CreatePrimitive(PrimitiveType.Quad);	// Create a quad object for holding the gem texture.
		model = modelObject.AddComponent<TrainModel>();						// Add a gemModel script to control visuals of the gem.
		model.init(this);
	}

	float[] position(int i, int j){
		float x = (Screen.width / num_tiles_w) * (float) i + Screen.width / (num_tiles_w * 2);
		float y = (Screen.height / num_tiles_h) * (float) j + Screen.height / (num_tiles_h * 2);
		float[] returnMe  =  {x, y};
		return returnMe;
	}

	public void rotate(Vector2 start, Vector2 end) {
		;
	}

	public void straight(int t) {
		return (new Vector2 (0, t / (n * tileWidth), 0));
	}

	public void left(int t) {
		return (new Vector2 (tileWidth * (Mathf.Cos(t) - 1), tileWidth * (Mathf.Sin(t)), 0));
	}

	public void right(int t) {
		return (new Vector2 (-1 * (tileWidth * (Mathf.Cos(t) - 1)), tileWidth * (Mathf.Sin(t)), 0));
	}

	void Update() {
		;
	}
}