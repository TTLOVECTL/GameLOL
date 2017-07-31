using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InscriptionSystem;
using UnityEngine.UI;
using System;

namespace InscriptionSystem.UI
{
    public class InscriptionPagePanel : MonoBehaviour
    {
        public Text levelText;

        public Text attributeText;

        public GameObject contentObject;

        public GameObject instantObject;

        public void OnReciveFromInscriptionPage(InscriptionPage inscriptionPage) {
            inscriptionPage.CalculatedAttribute();
            levelText.text = inscriptionPage.CalculatedInscriptionLevel().ToString();
            SortedDictionary<int,InscriptionAttribute> attributeList= inscriptionPage.inscriptionAttribute;
            attributeText.text = "";
            foreach (KeyValuePair<int, InscriptionAttribute> item in attributeList) {
                if (item.Value.valueType == AttributeValue.NUMBER)
                {
                    attributeText.text += (item.Value.attributeName + ":" + item.Value.attribueValue.ToString());
                }
                else {
                    string valuestring = (System.Math.Round(item.Value.attribueValue * 100,1)).ToString() + "%";
                    attributeText.text += (item.Value.attributeName + ":" + valuestring);
                }
                attributeText.text += "\n";
            }
        }
    }
}