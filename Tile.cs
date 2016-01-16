using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    private TileModel model;
    private int tileType;

	public int[] pos;
	public Quaternion orientation;

	public void init(int tileType) {
        this.tileType = tileType;

        var modelObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
        model = modelObject.AddComponent<TileModel>();
        model.init(tileType, this);
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
}
