
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUI : MonoBehaviour {
    public GameObject ga;

    public void ClickIP() {
        Debug.Log(ga.GetComponent<RectTransform>().localPosition);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
