using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test101 : MonoBehaviour {

    private Dropdown dropDownItem;
	// Use this for initialization
	void Start () {
        dropDownItem = GetComponent<Dropdown>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Onclick() {
        Debug.Log(dropDownItem.value);
    }
}
