using UnityEngine;
using System.Collections;

public class SetFog2Material : MonoBehaviour {
	//public Renderer Rend = null;
	public Material Mat = null;
	// Use this for initialization
	void Start () {
		//Rend = GetComponent<Renderer>();
		Mat = (Material)Resources.Load("Material/Fog1",typeof(Material));
		//Rend.sharedMaterial = Mat;
		Mat.shader = Shader.Find("Particles/Additive");
		Mat.mainTexture = (Texture)Resources.Load("Image/Fog01",typeof(Texture));



	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
