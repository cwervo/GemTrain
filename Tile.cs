/* Tile.cs
 * The tile's logic
 * John Burnett, Andres Cuervo, Sage Jenson
 * Gem Train
 * 2015-01-17
 */

using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    private TileModel model;
    private int tile_type;

	public int[] pos;
	public Quaternion orientation;

	public void init(int tile_type) {
        this.tile_type = tile_type;

       	GameObject modelObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
        model = modelObject.AddComponent<TileModel>();
        model.init(tile_type, this);

		orientation = Quaternion.Euler(0f, 0f, (orientation.eulerAngles.z - (90f*Random.Range(0, 4))) % 360f);
		transform.localRotation = orientation;
    }

	public void rotate() {
		orientation = Quaternion.Euler(0f, 0f, (orientation.eulerAngles.z - 90f) % 360f);
		transform.localRotation = orientation;
	}

	public int[] getPos() {
		return pos;
	}

	public void setPos(int[] new_pos) {
		pos = new_pos;
	}

	// Returns orientation:
	// 0 = 0 degree rotation
	// 1 = 90 degree rotation
	// 2 = 180 degree rotation
	// 3 = 270 degree rotation
	public int getRot() {
		if (0 == tile_type) {
			return -1;
		} else  {
			return (int)orientation.eulerAngles.z / 90;
		}
	}
}
