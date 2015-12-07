using UnityEngine;
using System.Collections;

public class SetRuneMaterial : MonoBehaviour {

	private Renderer Rend = null;
	private Material Mat = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void init(int runeID){
	
		//get Render
		Rend = GetComponent<Renderer>();

		//set Material
		Mat = (Material)Resources.Load("Material/GlowRune " + runeID.ToString(),typeof(Material));
		Rend.sharedMaterial = Mat;

		//set Material Shader
		Mat.shader = Shader.Find("Legacy Shaders/Transparent/Diffuse");

		//set Material Textue
		Mat.mainTexture = (Texture)Resources.Load("Image/rune" + runeID.ToString(),typeof(Texture));

		//gameObject.AddComponent<ColorChanger>();
	}
}
