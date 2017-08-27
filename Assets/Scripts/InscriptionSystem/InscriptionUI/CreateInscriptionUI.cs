using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InscriptionSystem;

namespace InscriptionSystem.UI
{
    /// <summary>
    /// 创建符文显示的UI
    /// </summary>
    public class CreateInscriptionUI : MonoBehaviour
    {
        public Sprite blueTypeImage;

        public Sprite yellowTyprImage;

        public List<Image> typeButtonImage;


        public List<Image> levelButtonImage;

        /// <summary>
        /// 实例化物体
        /// </summary>
        public GameObject instance;

       /// <summary>
       /// 实例化物体的父对象
       /// </summary>
        public GameObject contentObj;

        /// <summary>
        /// 当前符文等级
        /// </summary>
        private int inscriptionLevel = 5;

        /// <summary>
        /// 当前符文类型
        /// </summary>
        private AttribueType inscriptionType = AttribueType.ALL;

        /// <summary>
        /// 对应当前符文类型和等级的所有符文
        /// </summary>
        private List<Inscription> _inscriptionList;

        /// <summary>
        /// 父物体的Transform组件
        /// </summary>
        private RectTransform contentTransform;

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

        void Start()
        {
            _inscriptionList = XmlDataRead.inscriptionList;
            contentTransform = contentObj.GetComponent<RectTransform>();
            rectWidth = GetComponent<RectTransform>().rect.width;
            rectHeight = GetComponent<RectTransform>().rect.height;
            buttonwidth = (rectWidth- 4) / 3;
            buttonheight = buttonwidth / 2;
            typeButtonImage[0].sprite = yellowTyprImage;
            ChooseDeal();
        }

        /// <summary>
        ///按钮响应事件：设置选择的符文等级
        /// </summary>
        /// <param name="level"></param>
        public void OnChooseLevelButton(int level) {
            inscriptionLevel = level;
            ChooseDeal();
        }

        /// <summary>
        /// 按钮响应事件：设置选择的符文类型
        /// </summary>
        /// <param name="type"></param>
        public void OnChooseTypeButtoon(int type) {
            int a = (int)inscriptionType;
            typeButtonImage[a].sprite = blueTypeImage;
            typeButtonImage[type].sprite = yellowTyprImage;
            inscriptionType = (AttribueType)type;
            ChooseDeal();
        }
 

        /// <summary>
        /// 根据选择的等级和类型筛选出合适的符文
        /// </summary>
        private void ChooseDeal() {
            List<Inscription> resultList = GetInScription();
            Transform[] transformList = contentObj.GetComponentsInChildren<Transform>();
            foreach (Transform ta in transformList) {
                if (ta.tag == "Inscription")
                {
                    Destroy(ta.gameObject);
                }
            }
            int number = resultList.Count / 3;
            if (resultList.Count % 3 > 0)
            {
                number = resultList.Count / 3 + 1;
            }
            float height = number*buttonheight+number;
            if (height < rectHeight) {
                height = rectHeight;
            }
            contentTransform.sizeDelta = new Vector2(0, height);
            float y = -(buttonwidth / 4 + 1);
            int count = 0;
            for (int i = 0; i < number; i++)
            {
                float x = (buttonwidth +1)/2;
                for (int j = 0; j < 3; j++)
                {
                    count++;
                    if (count <= resultList.Count)
                    {
                        GameObject ga = Instantiate(instance);
                        ga.GetComponent<RectTransform>().SetParent(contentObj.transform);
                        ga.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - buttonwidth), buttonheight);
                        ga.GetComponent<RectTransform>().localPosition = new Vector2(j * (buttonwidth + 1) + x, -i * (buttonheight + 1) + y);
                        InscriptionButton inscriptionButton = ga.GetComponent<InscriptionButton>();
                        Inscription inscription = resultList[count - 1];
                        inscriptionButton.inscription = inscription._inscriptionID;
                        inscriptionButton.level = inscription._inscriptionLevel;
                        inscriptionButton.inscriptionName.text = inscription.inscriptionLevel.ToString()+"级铭文："+inscription.inscriptionName;
                        inscriptionButton.inscriptionSprite.sprite = inscription._inscriptionIcon;
                        inscriptionButton.otherJieShao.text = "未获得";
                        int temp = 0;
                        foreach (InscriptionAttribute item in inscription.inscriptionAttribute) {
                            string value = "";
                            if (item.valueType == AttributeValue.NUMBER)
                            {
                                value = item.attribueValue.ToString();
                            }
                            else {
                                value = System.Math.Round(item._attributeValue * 100, 1).ToString() + "%";
                            }
                            inscriptionButton.inscriptionAttribute[temp].text = item.attributeName + ":+" + value;
                            temp++;
                        }
                    }
                }
            }
            
           


        }

        /// <summary>
        /// 实例化所有的符文
        /// </summary>
        /// <returns></returns>
        private List<Inscription> GetInScription() {
            List<Inscription> list = new List<Inscription>();
            foreach (Inscription insc in _inscriptionList) {
                if ((insc.inscriptionLevel == inscriptionLevel)&& IsLookInscription(insc)){
                    list.Add(insc);
                }
            }
            return list;
        }

        /// <summary>
        /// 是否是要查找的符文
        /// </summary>
        /// <param name="insca"></param>
        /// <returns></returns>
        private bool IsLookInscription(Inscription insca) {
            switch (inscriptionType) {
                case AttribueType.ALL:
                    return true;
                case AttribueType.ATTACK:
                    foreach(InscriptionAttribute item in insca.inscriptionAttribute) {
                        if (item.attributeId == 1 || item.attributeId == 2) {
                            return true;
                        }
                    }
                    break;
                case AttribueType.DEFENSE:
                    foreach (InscriptionAttribute item in insca.inscriptionAttribute)
                    {
                        if (item.attributeId == 3 || item.attributeId == 4)
                        {
                            return true;
                        }
                    }
                    break;
                case AttribueType.BAOJI:
                    foreach (InscriptionAttribute item in insca.inscriptionAttribute)
                    {
                        if (item.attributeId == 12 || item.attributeId == 13)
                        {
                            return true;
                        }
                    }
                    break;
                case AttribueType.PENETRATION:
                    foreach (InscriptionAttribute item in insca.inscriptionAttribute)
                    {
                        if (item.attributeId == 7 || item.attributeId == 8)
                        {
                            return true;
                        }
                    }
                    break;
                case AttribueType.SPEED:
                    foreach (InscriptionAttribute item in insca.inscriptionAttribute)
                    {
                        if (item.attributeId == 10 )
                        {
                            return true;
                        }
                    }
                    break;
                case AttribueType.Tool:
                    foreach (InscriptionAttribute item in insca.inscriptionAttribute)
                    {
                        if (item.attributeId == 9  || item.attributeId == 14 
                            || item.attributeId == 15 || item.attributeId == 16 || item.attributeId == 17)
                        {
                            return true;
                        }
                    }
                    break;
                case AttribueType.VAMPIRE:
                    foreach (InscriptionAttribute item in insca.inscriptionAttribute)
                    {
                        if (item.attributeId == 5 || item.attributeId == 6)
                        {
                            return true;
                        }
                    }
                    break;
                case AttribueType.LIFE:
                    foreach (InscriptionAttribute item in insca.inscriptionAttribute)
                    {
                        if (item.attributeId == 11)
                        {
                            return true;
                        }
                    }
                    break;
            }

            return false;
        }

    }
}