using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    private TileModel model;		// The model object.
    private int tileType;		// Will determine the color and animation for the model.
	private int[] pos;

    // The Start function is good for initializing objects, but doesn't allow you to pass in parameters.
    // For any initialization that requires input, you'll probably want your own init function.

	public void init(int tileType) {
        this.tileType = tileType;

        var modelObject = GameObject.CreatePrimitive(PrimitiveType.Quad);	// Create a quad object for holding the gem texture.
        model = modelObject.AddComponent<TileModel>();						// Add a gemModel script to control visuals of the gem.
        model.init(tileType, this);
    }

	public int[] getPos() {
		return pos;
	}

	public void setPos(int[] new_pos) {
		pos = new_pos;
	}
}
