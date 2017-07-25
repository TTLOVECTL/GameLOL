using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCopy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        person A = new person();
        person B = CopyTool.DeepCopy<person>(A);
        Debug.Log(B.a);
        B.a = 2;
        Debug.Log(A.a);
        Debug.Log(B.a);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    class person {
        public int a = 1;
        public string b = "12321";
    }
}
