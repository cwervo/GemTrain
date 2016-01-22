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
	Vector2 location;
	public Tile current_tile;
	int t, n;

	TrainManager owner;

	// Use this for initialization
	//	public void init(int i, int j, Vector2 start_dir, int num_tiles_w, int num_tiles_h){
	public void init(int i, int j, int start_dir, TrainManager owner) {
		this.owner = owner;
		this.num_tiles_w = owner.num_tiles_w;
		this.num_tiles_h = owner.num_tiles_h;
		this.n = owner.owner.n;
		this.direction = start_dir;
		tile_width = Screen.width / num_tiles_w;

		this.transform.rotation = Quaternion.Euler(0f, 0f, (90f * direction)%360f);
		this.transform.Rotate (Vector2.right * direction);

		float[] pos = position (i, j);
		location = new Vector2 (pos [0], pos [1]);
		current_tile = owner.owner.board.tiles [i] [j];
		this.transform.position = Camera.main.ScreenToWorldPoint (
			new Vector3 (location.x, location.y, 8));

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
		loc = Camera.main.WorldToScreenPoint (loc);
		int i = (int) System.Math.Floor((double) loc.y / (Screen.height / num_tiles_h));
		int j = (int) System.Math.Floor((double) loc.x / (Screen.width / num_tiles_w));
		int[] pos = { i, j };
		return pos;
	}

	void Update() {
		transform.position += transform.up * 1 * Time.deltaTime;
//		transform.position = new Vector3 (
//			transform.position.x % Screen.width, 
//			transform.position.y % Screen.height, 
//			8);
		// update current tile
		int[] tile_pos = whichTile(this.transform.position);
		print (tile_pos [0] + ", " + tile_pos [1]);
		current_tile = owner.owner.board.tiles [tile_pos [0]] [tile_pos [1]];
		int tile_orientation = current_tile.getRot();
		this.transform.rotation = Quaternion.Euler(0f, 0f, (90f * tile_orientation)%360f);
	}


	int turn(int tile_orientation) {
		return (orientation - tile_orientation) % 4;
	}
}