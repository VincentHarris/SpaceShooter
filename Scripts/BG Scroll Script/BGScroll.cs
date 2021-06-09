using UnityEngine;
using System.Collections;

public class BGScroll : MonoBehaviour {

	public float scrollSpeed = 0.1f;

	private MeshRenderer meshRenderer;
	private float xScroll;

	void Awake(){
		meshRenderer = GetComponent<MeshRenderer> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Scroll ();
	}

	void Scroll(){
		xScroll = Time.time * scrollSpeed;

		Vector2 offset = new Vector2 (xScroll, 0f);
		meshRenderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}
}
