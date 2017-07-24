using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using InscriptionSystem;

public class Test : MonoBehaviour {
    public List<Inscription> a;

    private void readAsset()
    {
        BookElementHolder ceh = AssetDatabase.LoadAssetAtPath<BookElementHolder>("Assets/TT.asset");
        if (ceh == null) {
            Debug.Log("dasdsadsa");
            return;
        }
        Debug.Log(ceh.inscription.Count);
        foreach (Inscription gd in ceh.inscription)
        {
            Debug.Log(gd.inscriptionName);
        }
    }

    // Use this for initialization
    void Start () {
        readAsset();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
