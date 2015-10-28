using UnityEngine;
using System.Collections;

public class TestSetMaterial : MonoBehaviour {

	public Material glowmaterial; 
	public Renderer renderer;
	public static int index =0;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer>();
		glowmaterial = (Material)Resources.Load("TestMat",typeof(Material));
		renderer.sharedMaterial = glowmaterial;
		glowmaterial.shader = Shader.Find("Glow 11/Unity/Particles/Alpha Blended");
		glowmaterial.mainTexture = (Texture)Resources.Load("rune1",typeof(Texture));
		gameObject.AddComponent<ColorChanger>();
		index++;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
