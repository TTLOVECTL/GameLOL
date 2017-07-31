using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InscriptionSystem;
using UnityEngine.UI;
using System;

namespace InscriptionSystem.UI
{
    /// <summary>
    /// 符文综合属性显示面板
    /// </summary>
    public class InscriptionPagePanel : MonoBehaviour
    {
        /// <summary>
        /// 符文综合等级显示
        /// </summary>
        public Text levelText;

        /// <summary>
        /// 符文综合属性显示
        /// </summary>
        public Text attributeText;

        public GameObject contentObject;

        public GameObject instantObject;


        /// <summary>
        /// SendMessage函数的接受体
        /// </summary>
        /// <param name="inscriptionPage"></param>
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