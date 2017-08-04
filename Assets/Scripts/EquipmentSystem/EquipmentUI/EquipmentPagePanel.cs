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

        private SortedDictionary<int, GameObject> _smallGameObjectList=new SortedDictionary<int, GameObject>();
        
        /// <summary>
        /// 存储中件装备
        /// </summary>
        private List<EquipmentComponent> _middleEquipmentLis;

        private SortedDictionary<int, GameObject> _middleGameObjectList = new SortedDictionary<int, GameObject>();

        /// <summary>
        /// 存储大件装备
        /// </summary>
        private List<EquipmentComponent> _bigEquipmentList;

        private SortedDictionary<int, GameObject> _bigGameObjectList = new SortedDictionary<int, GameObject>();

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
            //ClearAllObject();
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
                eqb.GetComponent<Image>().sprite = lefeitem.equipmentIcor;

                ga.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                ga.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth-buttonwidth),buttonheight);
                ga.GetComponent<RectTransform>().localPosition = new Vector2(-2*buttonwidth,-count*(buttonheight*3/2)-buttonheight);

                nameObj.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                nameObj.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - buttonwidth / 2), buttonheight / 2);
                nameObj.GetComponent<RectTransform>().localPosition = new Vector2(-5 * buttonwidth / 4, -count * (buttonheight * 3 / 2) - 3 * buttonheight / 4);

                priceObj.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                priceObj.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - buttonwidth / 2), buttonheight / 2);
                priceObj.GetComponent<RectTransform>().localPosition = new Vector2(-5 * buttonwidth / 4, -count * (buttonheight * 3 / 2) - 5 * buttonheight / 4);

                _smallGameObjectList.Add(lefeitem.equipmentId,ga);

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
                eqb.GetComponent<Image>().sprite = lefeitem.equipmentIcor;

                ga.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                ga.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - buttonwidth), buttonheight);
                ga.GetComponent<RectTransform>().localPosition = new Vector2(0, -count * (buttonheight * 3 / 2) - buttonheight);

                nameObj.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                nameObj.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - buttonwidth / 2), buttonheight / 2);
                nameObj.GetComponent<RectTransform>().localPosition = new Vector2(3 * buttonwidth / 4, -count * (buttonheight * 3 / 2) - 3 * buttonheight / 4);

                priceObj.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                priceObj.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - buttonwidth / 2), buttonheight / 2);
                priceObj .GetComponent<RectTransform>().localPosition = new Vector2(3 * buttonwidth / 4, -count * (buttonheight * 3 / 2) - 5 * buttonheight / 4);

                _middleGameObjectList.Add(lefeitem.equipmentId,ga);
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
                eqb.GetComponent<Image>().sprite = lefeitem.equipmentIcor;

                ga.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                ga.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - buttonwidth), buttonheight);
                ga.GetComponent<RectTransform>().localPosition = new Vector2(2 * buttonwidth, -count * (buttonheight * 3 / 2) - buttonheight);

                nameObj.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                nameObj.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - buttonwidth/2), buttonheight/2);
                nameObj.GetComponent<RectTransform>().localPosition = new Vector2(11 * buttonwidth / 4, -count * (buttonheight * 3 / 2) - 3 * buttonheight / 4);

                priceObj.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                priceObj.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - buttonwidth/2), buttonheight/2);
                priceObj .GetComponent<RectTransform>().localPosition = new Vector2(11 * buttonwidth / 4, -count * (buttonheight * 3 / 2) - 5 * buttonheight / 4);

                _bigGameObjectList.Add(lefeitem.equipmentId,ga);
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

        public void OnDrawConnection() {
            foreach (Transform item in EquipmentUIResourceManage.Instance.EquipmentPageContent.GetComponentsInChildren<Transform>()) {
                if (item.gameObject.tag == "Line") {
                    Destroy(item.gameObject);
                }
            }

            EquipmentButton eqb = EquipmentButton.currentEquipmentButton.GetComponent<EquipmentButton>();

            if (eqb.equipmentType == EqunipmentType.SMALL)
            {

            }

            else if (eqb.equipmentType == EqunipmentType.MIDDLE)
            {
                RectTransform eqbTransform = _middleGameObjectList[eqb.equipemntId].GetComponent<RectTransform>();
                float maxposY = eqbTransform.localPosition.y;
                float minposY = eqbTransform.localPosition.y;
                float posX = eqbTransform.localPosition.x -  buttonwidth;

                GameObject lineobj0 = Instantiate(EquipmentUIResourceManage.Instance.DrawLineInstacneObj) as GameObject;
                lineobj0.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                lineobj0.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - buttonwidth / 2), 3f);
                lineobj0.GetComponent<RectTransform>().localPosition = new Vector2(eqbTransform.localPosition.x - buttonwidth * 3 / 4, eqbTransform.localPosition.y);

                EquipmentComponent eqcom = EquipmentFactory.Instance.GetMiddleEquipmentById(eqb.equipemntId);
                foreach (EquipmentLeaf leaf in eqcom.equipmentLeafList) {
                    if (!_smallGameObjectList.ContainsKey(leaf.equipmentId)){
                        continue;
                    }
                    RectTransform a = _smallGameObjectList[leaf.equipmentId].GetComponent<RectTransform>();
                    GameObject lineobj2 = Instantiate(EquipmentUIResourceManage.Instance.DrawLineInstacneObj) as GameObject;
                    lineobj2.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                    lineobj2.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - buttonwidth / 2), 3f);
                    lineobj2.GetComponent<RectTransform>().localPosition = new Vector2(a.localPosition.x+buttonwidth*3/4,a.localPosition.y);

                    

                    if (a.localPosition.y > maxposY)
                    {
                        maxposY = a.localPosition.y;
                    }
                    else if (a.localPosition.y < minposY) {
                        minposY = a.localPosition.y;
                    }
                }

                if (eqcom.equipmentCompmenTList.Count > 0) {
                    foreach (EquipmentComponent compoment in eqcom.equipmentCompmenTList) {
                        if (!_middleGameObjectList.ContainsKey(compoment.equipmentId)) {
                            continue;
                        }
                        RectTransform a = _middleGameObjectList[compoment.equipmentId].GetComponent<RectTransform>();
                        GameObject lineobj1 = Instantiate(EquipmentUIResourceManage.Instance.DrawLineInstacneObj) as GameObject;
                        lineobj1.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                        lineobj1.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - buttonwidth / 2), 3f);
                        lineobj1.GetComponent<RectTransform>().localPosition = new Vector2(a.localPosition.x - buttonwidth * 3 / 4, a.localPosition.y);
            
                        if (a.localPosition.y > maxposY)
                        {
                            maxposY = a.localPosition.y;
                        }
                        else if (a.localPosition.y < minposY)
                        {
                            minposY = a.localPosition.y;
                        }
                    }
                }

                GameObject lineobj = Instantiate(EquipmentUIResourceManage.Instance.DrawLineInstacneObj) as GameObject;
                lineobj.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                lineobj.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - 5), maxposY-minposY);
                lineobj.GetComponent<RectTransform>().localPosition = new Vector2(posX,(maxposY+minposY)/2);

            }

            else if (eqb.equipmentType == EqunipmentType.BIG) {
                RectTransform eqbTransform = _bigGameObjectList[eqb.equipemntId].GetComponent<RectTransform>();
                float maxposY = eqbTransform.localPosition.y;
                float minposY = eqbTransform.localPosition.y;
                float posX = eqbTransform.localPosition.x - buttonwidth;

                GameObject lineobj0 = Instantiate(EquipmentUIResourceManage.Instance.DrawLineInstacneObj) as GameObject;
                lineobj0.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                lineobj0.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - buttonwidth / 2), 3f);
                lineobj0.GetComponent<RectTransform>().localPosition = new Vector2(eqbTransform.localPosition.x - buttonwidth * 3 / 4, eqbTransform.localPosition.y);
                EquipmentComponent eqcom = EquipmentFactory.Instance.GetBigEquipmentById(eqb.equipemntId);

                if (eqcom.equipmentCompmenTList.Count > 0)
                {
                    foreach (EquipmentComponent compoment in eqcom.equipmentCompmenTList)
                    {
                        if (!_middleGameObjectList.ContainsKey(compoment.equipmentId))
                        {
                            continue;
                        }

                        RectTransform a = _middleGameObjectList[compoment.equipmentId].GetComponent<RectTransform>();
                        GameObject lineobj1 = Instantiate(EquipmentUIResourceManage.Instance.DrawLineInstacneObj) as GameObject;
                        lineobj1.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                        lineobj1.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - buttonwidth / 2), 3f);
                        lineobj1.GetComponent<RectTransform>().localPosition = new Vector2(a.localPosition.x + buttonwidth * 3 / 4, a.localPosition.y);

                        if (a.localPosition.y > maxposY)
                        {
                            maxposY = a.localPosition.y;
                        }

                        else if (a.localPosition.y < minposY)
                        {
                            minposY = a.localPosition.y;
                        }
                    }
                }

                GameObject lineobj = Instantiate(EquipmentUIResourceManage.Instance.DrawLineInstacneObj) as GameObject;
                lineobj.GetComponent<RectTransform>().SetParent(EquipmentUIResourceManage.Instance.EquipmentPageContent.transform);
                lineobj.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - 5), maxposY - minposY);
                lineobj.GetComponent<RectTransform>().localPosition = new Vector2(posX, (maxposY + minposY) / 2);

            }
        }

        private  void ClearAllObject() {
            if (EquipmentUIResourceManage.Instance.EquipmentPageContent.GetComponentsInChildren<Transform>().Length > 0)
            {
                foreach (Transform item in EquipmentUIResourceManage.Instance.EquipmentPageContent.GetComponentsInChildren<Transform>())
                {
                     
                     Destroy(item.gameObject);
                    
                }
            }
        }
    }
}