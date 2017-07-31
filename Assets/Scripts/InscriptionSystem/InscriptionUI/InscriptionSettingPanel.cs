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
            foreach (int a in InscriptionConst._instriptionBag) {
                Inscription inscription=InscriptionFactory.Instance.GetInscriptionById(a);
                if (inscription.inscriptionColor == currentButton.GetComponent<InscriptionSlotButton>().slotColor) {
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
                    GameObject ga = Instantiate(initscerObj);
                    ga.GetComponent<RectTransform>().SetParent(contentObj.transform);
                    ga.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth-buttonwidth), buttonheight);

                    ga.GetComponent<RectTransform>().localPosition = new Vector2(buttonwidth/2+5, -count * (buttonheight + 10) - (buttonheight/2+5));

                    ga.GetComponent<SettingInscriptionButton>().inscriptionId = a.inscriptionID;

                    ga.GetComponent<Image>().sprite = tempSprite[a.inscriptionID];
                    count++;
                }
            }
        }
    }
}