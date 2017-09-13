using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginUIController : MonoBehaviour {
    public GameObject registPanel;

    public GameObject loginPanel;

    public GameObject noticePanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnLoginButtonEntry() {
        loginPanel.SetActive(true);
    }

    public void OnRegisterButtonEntry() {

        registPanel.SetActive(true);
    }

    public void OnCloseRegisterPanel() {
        registPanel.SetActive(false);
    }

    public void OnCloseLoginPanel() {
        loginPanel.SetActive(false);
    }
}
