using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InscriptionSystem;
using UnityEngine.UI;
namespace InscriptionSystem.UI
{
    public class InscriptionSettingPanel : MonoBehaviour
    {
        public Sprite[] tempSprite;

        private GameObject currentButton;

        private List<Inscription> inscriptionList = new List<Inscription>();

        public GameObject initscerObj;

        /// <summary>
        /// 实例化物体的宽度
        /// </summary>
        private float buttonwidth;

        /// <summary>
        /// 父物体的宽度
        /// </summary>
        private float rectWidth;

        /// <summary>
        /// 父物体的高度
        /// </summary>
        private float rectHeight;

        /// <summary>
        /// 实例化物体的高度
        /// </summary>
        private float buttonheight;

        public GameObject contentObj;

        private void Start()
        {
            rectHeight = GetComponentInChildren<RectTransform>().rect.height;
            rectWidth = GetComponentInChildren<RectTransform>().rect.width;
            buttonwidth = rectWidth - 10;
            buttonheight = buttonwidth / 2;
        }


        public void OnReceiveMessage() {
            currentButton = InscriptionSlotButton.currentButton;                
            InitChooseFromBag();
        }

        private void InitChooseFromBag() {
            for (int i = 0; i < contentObj.transform.childCount; i++)
            {
                DestroyImmediate(contentObj.transform.GetChild(i).gameObject);
            }
            inscriptionList.Clear();

            foreach (int a in InscriptionConst._instriptionBag)
            {
                Inscription inscription = InscriptionFactory.Instance.GetInscriptionById(a);
                if (inscription.inscriptionColor == currentButton.GetComponent<InscriptionSlotButton>().slotColor)
                {
                    inscriptionList.Add(inscription);
                }
            }
            if (inscriptionList.Count != 0) {
                float he = inscriptionList.Count * (buttonheight+5)+5;
                if (he < rectHeight) {
                    he = rectHeight;
                }
                contentObj.GetComponent<RectTransform>().sizeDelta = new Vector2(0,he);
                int count = 0;
                foreach(Inscription a in inscriptionList) {
                    GameObject ga = Instantiate(initscerObj) as GameObject;

                    ga.GetComponent<RectTransform>().SetParent(contentObj.transform);

                    ga.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth-buttonwidth), buttonheight);

                    ga.GetComponent<RectTransform>().localPosition = new Vector2(buttonwidth/2+5, -count * (buttonheight + 10) - (buttonheight/2+5));

                    SettingInscriptionButton settingInscriptionButton = ga.GetComponent<SettingInscriptionButton>();
                    settingInscriptionButton.inscriptionId = a.inscriptionID;
                    settingInscriptionButton.iocnSprite.sprite = a.inscriptionIcon;
                    settingInscriptionButton.inscriptionName.text =a.inscriptionLevel+"级符文："+ a.inscriptionName;
                    for (int i = 0; i < a.inscriptionAttribute.Count; i++) {
                        string value = "";
                        if (a.inscriptionAttribute[i].valueType == AttributeValue.PERCENTAGE) {
                            value = System.Math.Round(a.inscriptionAttribute[i]._attributeValue * 100, 1).ToString() + "%";
                        }
                        else {
                            value = a.inscriptionAttribute[i]._attributeValue.ToString();
                        }
                        settingInscriptionButton.inscriptionAttribute[i].text = a.inscriptionAttribute[i].attributeName + ":+" + value;
                    }
                    count++;
                }
            }
        }
    }
}