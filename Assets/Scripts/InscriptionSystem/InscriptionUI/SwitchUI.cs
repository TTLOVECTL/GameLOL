using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InscriptionSystem.UI
{
    public class SwitchUI : MonoBehaviour
    {

        public GameObject InscriptionPageObject;

        public GameObject InscriptionBuyObject;
        // Use this for initialization
        void Start()
        {
            OnInscriptionPageChoose();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnInscriptionPageChoose()
        {
            InscriptionBuyObject.SetActive(false);
            InscriptionPageObject.SetActive(true);
        }

        public void OnInscriptionBuyChoose()
        {
            InscriptionBuyObject.SetActive(true);
            InscriptionPageObject.SetActive(false);
        }

    }
}
