using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InscriptionSystem;
namespace InscriptionSystem.UI
{
    public class SwitchUI : MonoBehaviour
    {
        private static SwitchUI instcne=null;

        private void Awake()
        {
            if (instcne == null) {
                instcne = this;
            }
        }

        public static SwitchUI Instcne {
            get {
                return instcne;
            }
        }

        public Sprite blueSprite;

        public Sprite yellowSprite;

        public GameObject InscriptionPageObject;

        public GameObject InscriptionBuyObject;

        public Image pageImage;

        public Image buyImage;

        public GameObject inscriptinBuy;

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
            pageImage.sprite = yellowSprite;
            InscriptionPageObject.SetActive(true);
            buyImage.sprite = blueSprite;
        }

        public void OnInscriptionBuyChoose()
        {
            InscriptionBuyObject.SetActive(true);
            pageImage.sprite = blueSprite;
            InscriptionPageObject.SetActive(false);
            buyImage.sprite = yellowSprite;
        }

    }
}
