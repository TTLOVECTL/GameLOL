using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateLoad : MonoBehaviour {

    private List<Texture2D> gifFrames = new List<Texture2D>();
    public float speed = 1f;
    public RawImage rawImage;
	// Use this for initialization
	void Start () {
        gifFrames = GetComponent<LoadFrame>().gifFrames;
	}

	// Update is called once per frame
	void Update () {
        rawImage.texture = gifFrames[(int)(Time.frameCount * speed) % gifFrames.Count];
	}
}
