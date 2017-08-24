using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InscriptionSystem;
public class Test100 : MonoBehaviour {
    
    bool flag = true;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (XmlDataRead.inscriptionList != null && flag) {
            foreach (Inscription a in XmlDataRead.inscriptionList) {
                //Debug.Log(a._inscriptionName);
            }
            flag = false;
        }
	}
}
