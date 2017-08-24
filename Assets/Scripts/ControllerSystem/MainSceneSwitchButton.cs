using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneSwitchButton : MonoBehaviour {
    public void OnSwitchInscriptionScene() {
        SceneManager.LoadScene("InscriptionScene");
    }
}
