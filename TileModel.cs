/* TileModel.cs
 * The tile's visual interface
 * John Burnett, Andres Cuervo, Sage Jenson
 * Gem Train
 * 2015-01-17
 */

using UnityEngine;
using System.Collections;

public class TileModel : MonoBehaviour {

	private int tile_type;		// 0 for blank; 1 for turn
    private Tile owner;			// Pointer to the parent object.
    private Material mat;		// Material for setting/changing texture and color.

	public void init(int tile_type, Tile owner) {
        this.owner = owner;
        this.tile_type = tile_type;

        transform.parent = owner.transform;					// Set the model's parent to the gem.
        transform.localPosition = new Vector3(0,0,0);		// Center the model on the parent.
        name = "Tile Model";									// Name the object.

        mat = GetComponent<Renderer>().material;								// Get the material component of this quad object.
		if (tile_type == 0) {
	        mat.mainTexture = Resources.Load<Texture2D>("Textures/tileBlank");	// Set the texture.  Must be in Resources folder
		} else if (tile_type == 1) {
	        mat.mainTexture = Resources.Load<Texture2D>("Textures/turnLights");	// Set the texture.  Must be in Resources folder
		}
        mat.color = new Color(1,1,1);											// Set the color (easy way to tint things).
        mat.shader = Shader.Find ("Transparent/Diffuse");						// Tell the renderer that our textures have transparency.
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
