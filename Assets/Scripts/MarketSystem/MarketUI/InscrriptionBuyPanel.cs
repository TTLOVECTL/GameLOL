using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InscriptionSystem.UI;
using UnityEngine.UI;

namespace MarketSystem.UI
{
    public class InscrriptionBuyPanel : MonoBehaviour
    {
        public Image inscriptionSprite;

        public Text inscriptionName;

        public Text outherAttibute;

        public List<Text> attibuteList;

        private int inscripptionId;


        private void Start()
        {
           
        }

        public void OnInitBuyInscriptionMessage(InscriptionBuyOrSell inscriptionBuyOrSell)
        {
            inscriptionSprite.sprite = inscriptionBuyOrSell.inscriptionSprite.sprite;
            inscriptionName.text = inscriptionBuyOrSell.inscriptionName.text;
            outherAttibute.text = "单价："+inscriptionBuyOrSell.buyText.text;
            for (int i = 0; i < attibuteList.Count; i++) {
                attibuteList[i].text = inscriptionBuyOrSell.attibuteList[i].text;
            }
        }

        public void OnCloseBuyInscriptionPanel() {
            this.gameObject.SetActive(false);
        }
    }
}
