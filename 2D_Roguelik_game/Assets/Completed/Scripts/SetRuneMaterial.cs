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
		Rend = GetComponent<Renderer>();
		runeID ++;	
		Mat = (Material)Resources.Load("Material/GlowRune " + runeID.ToString(),typeof(Material));
		Rend.sharedMaterial = Mat;
		Mat.shader = Shader.Find("Glow 11/Unity/Particles/Alpha Blended");
		Mat.mainTexture = (Texture)Resources.Load("Image/rune" + runeID.ToString(),typeof(Texture));
		gameObject.AddComponent<ColorChangerYellow>();
	}
}
