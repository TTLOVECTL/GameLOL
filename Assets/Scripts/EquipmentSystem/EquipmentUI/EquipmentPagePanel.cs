using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EquipmentSystem;
using UnityEngine.UI;
namespace EquipmentSystem.UI {
    public class EquipmentPagePanel : MonoBehaviour {

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

        /// <summary>
        /// 存储小件装备
        /// </summary>
        private List<EquipmentLeaf> _samllEquipmentList;

        /// <summary>
        /// 存储中件装备
        /// </summary>
        private List<EquipmentComponent> _middleEquipmentLis;
        /// <summary>
        /// 存储大件装备
        /// </summary>
        private List<EquipmentComponent> _bigEquipmentList;

        private void Start()
        {
            rectHeight = GetComponentInChildren<RectTransform>().rect.height;
            rectWidth = GetComponentInChildren<RectTransform>().rect.width;
            buttonwidth = rectWidth/6;
            buttonheight = buttonwidth;
        }

        /// <summary>
        /// SendMessage事件响应函数的接受体，来自LeftChoose的ChooseEquipmentSetting类
        /// </summary>
        public void OnSerchEquipment() {
            _samllEquipmentList = ChooseEquipmentSetting.Instance.smallEquipmentList;
            _middleEquipmentLis = ChooseEquipmentSetting.Instance.middleEquipmentList;
            _bigEquipmentList = ChooseEquipmentSetting.Instance.bigEquipmentList;
            InitEquipmentPage();
        }


        private void InitEquipmentPage() {
            int number = GetBigHeight();
            float he = number * buttonheight + (number + 1) * buttonheight / 2;
            if (he < rectHeight) {
                he = rectHeight;
            }
            EquipmentUIResourceManage.Instance.EquipmentPageContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0,he);

            int count = 0;
            foreach (EquipmentLeaf lefeitem in _samllEquipmentList) {
                GameObject ga = Instantiate(EquipmentUIResourceManage.Instance.EquipmentInstantiateObj) as GameObject;

                GameObject nameObj = Instantiate(EquipmentUIResourceManage.Instance.EquipmentInstantiateTextObj) as GameObject;

                GameObject priceObj = Instantiate(EquipmentUIResourceManage.Instance.EquipmentInstantiateTextObj) as GameObject;

                nameObj.GetComponent<Text>().text = lefeitem.equipmentName;

                priceObj.GetComponent<Text>().text = lefeitem.equipmentPrice.ToString();

                EquipmentButton eqb = ga.GetComponent<EquipmentButton>();
                eqb.searchType = lefeitem.seaechType;
                eqb.equipemntId = lefeitem.equipmentId;
                eqb.equipmentType = lefeitem.equipmentType;

                ga.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                ga.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth-buttonwidth),buttonheight);
                ga.GetComponent<RectTransform>().localPosition = new Vector2(-2*buttonwidth,-count*(buttonheight*3/2)-buttonheight);

                nameObj.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                nameObj.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - buttonwidth / 2), buttonheight / 2);
                nameObj.GetComponent<RectTransform>().localPosition = new Vector2(-5 * buttonwidth / 4, -count * (buttonheight * 3 / 2) - 3 * buttonheight / 4);

                priceObj.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                priceObj.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - buttonwidth / 2), buttonheight / 2);
                priceObj.GetComponent<RectTransform>().localPosition = new Vector2(-5 * buttonwidth / 4, -count * (buttonheight * 3 / 2) - 5 * buttonheight / 4);
                count++;
            }
            count = 0;
            foreach (EquipmentComponent lefeitem in _middleEquipmentLis)
            {
                GameObject ga = Instantiate(EquipmentUIResourceManage.Instance.EquipmentInstantiateObj) as GameObject;

                GameObject nameObj = Instantiate(EquipmentUIResourceManage.Instance.EquipmentInstantiateTextObj) as GameObject;

                GameObject priceObj = Instantiate(EquipmentUIResourceManage.Instance.EquipmentInstantiateTextObj) as GameObject;

                nameObj.GetComponent<Text>().text = lefeitem.equipmentName;

                priceObj.GetComponent<Text>().text = lefeitem.equipmentPrice.ToString();

                EquipmentButton eqb = ga.GetComponent<EquipmentButton>();
                eqb.searchType = lefeitem.seaechType;
                eqb.equipemntId = lefeitem.equipmentId;
                eqb.equipmentType = lefeitem.equipmentType;

                ga.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                ga.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - buttonwidth), buttonheight);
                ga.GetComponent<RectTransform>().localPosition = new Vector2(0, -count * (buttonheight * 3 / 2) - buttonheight);

                nameObj.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                nameObj.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - buttonwidth / 2), buttonheight / 2);
                nameObj.GetComponent<RectTransform>().localPosition = new Vector2(3 * buttonwidth / 4, -count * (buttonheight * 3 / 2) - 3 * buttonheight / 4);

                priceObj.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                priceObj.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - buttonwidth / 2), buttonheight / 2);
                priceObj .GetComponent<RectTransform>().localPosition = new Vector2(3 * buttonwidth / 4, -count * (buttonheight * 3 / 2) - 5 * buttonheight / 4);
                count++;
            }

            count = 0;
            foreach (EquipmentComponent lefeitem in _bigEquipmentList)
            {
                GameObject ga = Instantiate(EquipmentUIResourceManage.Instance.EquipmentInstantiateObj) as GameObject;

                GameObject nameObj = Instantiate(EquipmentUIResourceManage.Instance.EquipmentInstantiateTextObj) as GameObject;

                GameObject priceObj = Instantiate(EquipmentUIResourceManage.Instance.EquipmentInstantiateTextObj) as GameObject;

                EquipmentButton eqb = ga.GetComponent<EquipmentButton>();

                nameObj.GetComponent<Text>().text = lefeitem.equipmentName;

                priceObj.GetComponent<Text>().text = lefeitem.equipmentPrice.ToString();

                eqb.searchType = lefeitem.seaechType;
                eqb.equipemntId = lefeitem.equipmentId;
                eqb.equipmentType = lefeitem.equipmentType;

                ga.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                ga.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - buttonwidth), buttonheight);
                ga.GetComponent<RectTransform>().localPosition = new Vector2(2 * buttonwidth, -count * (buttonheight * 3 / 2) - buttonheight);

                nameObj.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                nameObj.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - buttonwidth/2), buttonheight/2);
                nameObj.GetComponent<RectTransform>().localPosition = new Vector2(11 * buttonwidth / 4, -count * (buttonheight * 3 / 2) - 3 * buttonheight / 4);

                priceObj.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                priceObj.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - buttonwidth/2), buttonheight/2);
                priceObj .GetComponent<RectTransform>().localPosition = new Vector2(11 * buttonwidth / 4, -count * (buttonheight * 3 / 2) - 5 * buttonheight / 4);
                count++;
            }
        }

        /// <summary>
        /// 获取Content面板的最大高度
        /// </summary>
        /// <returns></returns>
        private int GetBigHeight()
        {
            int temp=_samllEquipmentList.Count;
            if (temp < _middleEquipmentLis.Count)
            {
                temp = _middleEquipmentLis.Count;
            }
            if (temp < _bigEquipmentList.Count) {
                temp = _bigEquipmentList.Count;
            }
            return temp;
        }
    }
}