using UnityEngine;
using System.Collections;

public class TrainModel : MonoBehaviour {

	Train owner;
	Material mat;

	public void init(Train owner) {
		this.owner = owner;

		transform.parent = owner.transform;					// Set the model's parent to the gem.
		transform.localPosition = new Vector3(0,0,0);		// Center the model on the parent.
		name = "Train Model";									// Name the object.

		mat = GetComponent<Renderer>().material;								// Get the material component of this quad object.
		mat.mainTexture = Resources.Load<Texture2D>("Textures/marble");	// Set the texture.  Must be in Resources folder
		mat.color = new Color(1,1,1);											// Set the color (easy way to tint things).
		mat.shader = Shader.Find ("Transparent/Diffuse");						// Tell the renderer that our textures have transparency.
	}
}
