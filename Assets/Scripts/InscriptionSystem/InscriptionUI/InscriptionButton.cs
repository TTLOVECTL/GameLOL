using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace InscriptionSystem
{
    public class InscriptionButton : MonoBehaviour
    {

        public int inscription = 0;

        public Image inscriptionSprite;
        public Text inscriptionName;
        public Text otherJieShao;
        public List<Text> inscriptionAttribute;

        public void OnSearchInscription()
        {
            if (inscription == 0) {
                return;
            }
        }
    }
}