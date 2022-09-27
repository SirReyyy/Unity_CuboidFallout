using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour {

	public float scrollSpeed = 0.2f;
	private MeshRenderer meshRenderer;
    
    private string MainTexture = "_MainTex"; //

	void Awake() {
		meshRenderer = GetComponent<MeshRenderer>();
	}

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        Scroll();
    }

    void Scroll() {
    	Vector2 offset = meshRenderer.sharedMaterial.GetTextureOffset(MainTexture);
        offset.y += Time.deltaTime * scrollSpeed;

        meshRenderer.sharedMaterial.SetTextureOffset(MainTexture, offset);
    }
}