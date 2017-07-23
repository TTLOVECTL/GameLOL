using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSize : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(GetComponent<RectTransform>().sizeDelta);
        Debug.Log(GetComponent<RectTransform>().localPosition);

        Debug.Log(GetComponent<RectTransform>().rect.size);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
