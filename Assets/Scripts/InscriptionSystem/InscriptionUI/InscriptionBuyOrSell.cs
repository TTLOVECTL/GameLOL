using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
using InscriptionSystem;
namespace InscriptionSystem.UI
{
    public class InscriptionBuyOrSell : MonoBehaviour
    {
        public Image inscriptionSprite;

        public Text inscriptionName;

        public Text outherAttibute;

        public List<Text> attibuteList;

        private int inscripptionId;

        public Text buyText;

        public Text SellText;

        public void OnSendMessageFromInscriptionButton(InscriptionButton inscriptionButton)
        {
            inscripptionId = inscriptionButton.inscription;
            inscriptionSprite.sprite = inscriptionButton.inscriptionSprite.sprite;
            inscriptionName.text = inscriptionButton.inscriptionName.text;
            outherAttibute.text = inscriptionButton.otherJieShao.text;
            
            for (int i = 0; i < attibuteList.Count; i++)
            {
                attibuteList[i].text = inscriptionButton.inscriptionAttribute[i].text;
            }

            string text1 = "";
            string text2 = "";
            switch (inscriptionButton.level) {
                case 1:
                    text1 = "10";
                    text2 = "10";
                    break;
                case 2:
                    text1 = "25";
                    text2 = "20";
                    break;
                case 3:
                    text1 = "100";
                    text2 = "80";
                    break;
                case 4:
                    text1 = "400";
                    text2 = "320";
                    break;
                case 5:
                    text1 = "1600";
                    text2 = "800";
                    break;
            }

            buyText.text = text1;
            SellText.text = text2;
        }

        public void OnInscriptionBuy()
        {

        }

        public void OnInscritionSell()
        {

        }

        public void OnCloseBuy()
        {
            gameObject.SetActive(false);
        }
    }
}