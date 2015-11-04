using UnityEngine;
using System.Collections;

public class SetFog1Material : MonoBehaviour {
	public Renderer Rend = null;
	public Material Mat = null;
	// Use this for initialization
	void Start () {
		Rend = GetComponent<Renderer>();
		Mat = (Material)Resources.Load("Material/Fog2",typeof(Material));
		Rend.sharedMaterial = Mat;
		Mat.shader = Shader.Find("Particles/Additive");
		Mat.mainTexture = (Texture)Resources.Load("Image/Fog02",typeof(Texture));
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
}
