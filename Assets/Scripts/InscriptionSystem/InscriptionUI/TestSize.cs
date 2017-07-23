using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSize : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(GetComponent<RectTransform>().rect);
        GetComponent<RectTransform>().sizeDelta = new Vector3(0,1000);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
