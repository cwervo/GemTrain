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
	int orientation;
	int direction;
	float tile_width;
	Vector2 location, base_pos;
	Tile current_tile;
	int t, n;

	TrainManager owner;

	// Use this for initialization
	//	public void init(int i, int j, Vector2 start_dir, int num_tiles_w, int num_tiles_h){
	public void init(int i, int j, int start_dir, TrainManager owner) {
		this.owner = owner;
		this.num_tiles_w = owner.num_tiles_w;
		this.num_tiles_h = owner.num_tiles_h;
		this.n = owner.owner.n;
		tile_width = Screen.width / num_tiles_w;
		base_pos = new Vector2 ();

		float[] pos = position (i, j);
		location = new Vector2 (pos [0], pos [1]);
		this.transform.position = Camera.main.ScreenToWorldPoint (
			new Vector3 (location.x, location.y - Screen.height/(num_tiles_h*2), 8));

		GameObject modelObject = GameObject.CreatePrimitive(PrimitiveType.Quad);	// Create a quad object for holding the gem texture.
		model = modelObject.AddComponent<TrainModel>();						// Add a gemModel script to control visuals of the gem.
		model.init(this);
	}

	float[] position(int i, int j){
		float x = (Screen.width / num_tiles_w) * (float) i + Screen.width / (num_tiles_w * 2);
		float y = (Screen.height / num_tiles_h) * (float) j + Screen.height / (num_tiles_h * 2);
		float[] returnMe  =  {x, y};
		return returnMe;
	}

	void setLocation(Vector2 loc) {
		location = loc;
	}

	int[] whichTile(Vector2 loc) {
		int i = (int) System.Math.Floor((double) loc.y / (Screen.height / num_tiles_h));
		int j = (int) System.Math.Floor((double) loc.x / (Screen.width / num_tiles_w));
		int[] pos = { i, j };
		return pos;
	}

	public Vector2 straight() {
		return (new Vector2 (0, t / (n * tile_width)));
	}

	public Vector2 left() {
		return (new Vector2 (tile_width * (Mathf.Cos(t) - 1), tile_width * (Mathf.Sin(t))));
	}

	public Vector2 right() {
		return (new Vector2 (-1 * (tile_width * (Mathf.Cos(t) - 1)), tile_width * (Mathf.Sin(t))));
	}


	Vector2 offset(int tile_orientation){
		Vector2 offset;
		if (0 == tile_orientation) {
			offset = right ();
		} else if (1 == tile_orientation) {
			offset = left ();
		} else {
			offset = straight ();
		}

		//TODO: rotate around the center of the tile based on the train's orientation
		return offset;
	}

	void updateLocation(){
		this.transform.position = Camera.main.ScreenToWorldPoint (
			new Vector3(location.x, location.y, 8));
	}

	void Update() {
		t = owner.owner.t;
		if (t == 0) {
			base_pos = location;
		}

		// get orientation of underlying tile
		int[] tile = whichTile(location);
		print (tile[0] + ", " + tile[1]);
		current_tile = owner.owner.board.tiles[tile[0]][tile[1]];
		int tile_orientation = current_tile.getRot();

		// call turn() to figure out where 2 go
		int dir = turn(tile_orientation);

		location = base_pos + offset (dir);
		this.transform.RotateAround (
			location,
			Camera.main.WorldToScreenPoint(current_tile.transform.position), 
			orientation * 90);
		updateLocation ();
	}


	int turn(int tile_orientation) {
		return (orientation - tile_orientation) % 4;
	}
}