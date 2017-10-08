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

        //private List<Inscription> inscriptionList = new List<Inscription>();

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
            Transform[] childsTransform = contentObj.GetComponentsInChildren<Transform>();
            for (int i = 0; i < childsTransform.Length; i++)
            {
                if (childsTransform[i].gameObject.tag == "SettingInscriptionButton")
                    Destroy(childsTransform[i].gameObject);
            }
            List<RestInscription> restList = InscriptionPageFactory.Instance.GetRestInscriptionList(currentButton.GetComponent<InscriptionSlotButton>().slotColor, 1);
            if (restList.Count != 0) {
                float he = restList.Count * (buttonheight+5)+5;
                if (he < rectHeight) {
                    he = rectHeight;
                }
                contentObj.GetComponent<RectTransform>().sizeDelta = new Vector2(0,he);
                int count = 0;

                
                foreach(RestInscription rest in restList) {
                    Inscription a = InscriptionFactory.Instance.GetInscriptionById(rest.inscriptionId);
                    GameObject ga = Instantiate(initscerObj) as GameObject;

                    ga.GetComponent<RectTransform>().SetParent(contentObj.transform);

                    ga.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth-buttonwidth), buttonheight);

                    ga.GetComponent<RectTransform>().localPosition = new Vector2(buttonwidth/2+5, -count * (buttonheight + 10) - (buttonheight/2+5));

                    SettingInscriptionButton settingInscriptionButton = ga.GetComponent<SettingInscriptionButton>();
                    settingInscriptionButton.inscriptionId = a.inscriptionID;
                    settingInscriptionButton.iocnSprite.sprite = a.inscriptionIcon;
                    settingInscriptionButton.inscriptionName.text =a.inscriptionLevel+"级符文："+ a.inscriptionName;
                    settingInscriptionButton.inscriptionNumber.text = "X" + rest.inscriptionNumber.ToString();
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