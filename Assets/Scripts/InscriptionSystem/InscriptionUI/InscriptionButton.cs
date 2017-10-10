using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InscriptionSystem;
namespace InscriptionSystem.UI
{
    public class InscriptionButton : MonoBehaviour
    {

        public int inscription = 0;
        public int level = 0;
        public Image inscriptionSprite;
        public Text inscriptionName;
        public Text otherJieShao;
        public List<Text> inscriptionAttribute;

        public GameObject inscriptionbuy;

        private void Start()
        {
            //inscriptionbuy = SwitchUI.Instcne.inscriptinBuy;
        }

        public void OnSearchInscription()
        {
            if (inscription == 0) {
                return;
            }
            inscriptionbuy.SetActive(true);
            inscriptionbuy.SendMessage("OnSendMessageFromInscriptionButton",this);
        }
    }
}