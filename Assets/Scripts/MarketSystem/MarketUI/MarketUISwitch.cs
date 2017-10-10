using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InscriptionSystem.UI;

namespace MarketSystem.UI {
    public class MarketUISwitch : MonoBehaviour {

        public GameObject inscriptionPanel;

        public GameObject heroPanel;

        public GameObject skinPanel;

        public CreateInscriptionUI createInscriptionUI;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnShowInscription()
        {
            inscriptionPanel.SetActive(true);
        }
    }
}
