using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

namespace InscriptionSystem
{
    /// <summary>
    /// 创建符文显示的UI
    /// </summary>
    public class CreateInscriptionUI : MonoBehaviour
    {
        /// <summary>
        /// 实例化物体
        /// </summary>
        public GameObject instance;

       /// <summary>
       /// 实例化物体的父对象
       /// </summary>
        public GameObject contentObj;

        /// <summary>
        /// 符文sprites列表
        /// </summary>
        public Sprite[] spriteList;

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
            InscriptionHolder ceh = AssetDatabase.LoadAssetAtPath<InscriptionHolder>("Assets/Resources/Inscription.asset");
            if (ceh == null)
            {
                return;
            }
            _inscriptionList = ceh.inscription;
            contentTransform = contentObj.GetComponent<RectTransform>();

            rectWidth = GetComponent<RectTransform>().rect.width;
            rectHeight = GetComponent<RectTransform>().rect.height;
            buttonwidth = (rectWidth- 4) / 3;
            buttonheight = buttonwidth / 2;

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
        public void OnChooseTypeButtoon(AttribueType type) {
            inscriptionType = type;
            ChooseDeal();
        }

        /// <summary>
        /// 根据选择的等级和类型筛选出合适的符文
        /// </summary>
        private void ChooseDeal() {
            List<Inscription> resultList = GetInScription();
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
                float x = -(buttonwidth +1);
                for (int j = 0; j < 3; j++)
                {
                    count++;
                    if (count <= resultList.Count)
                    {
                        GameObject ga = Instantiate(instance);
                        ga.GetComponent<RectTransform>().SetParent(contentObj.transform);
                        ga.GetComponent<RectTransform>().sizeDelta = new Vector2(-(rectWidth - buttonwidth), buttonheight);
                        ga.GetComponent<RectTransform>().localPosition = new Vector2(j * (buttonwidth +1) + x, -i * (buttonheight + 1) + y);
                        ga.GetComponent<InscriptionButton>().inscription = resultList[count - 1]._inscriptionID;
                        ga.GetComponent<Image>().sprite = spriteList[resultList[count - 1]._inscriptionID];
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
                    
                    break;
                case AttribueType.DEFENSE:
                    break;
                case AttribueType.BAOJI:
                    break;
                case AttribueType.PENETRATION:
                    break;
                case AttribueType.SPEED:
                    break;
                case AttribueType.Tool:
                    break;
                case AttribueType.VAMPIRE:
                    break;
            }

            return false;
        }

        private void SetAnchorsToCorner(RectTransform t) {
            RectTransform pt = t.parent as RectTransform;
            if (t == null || pt == null)
                return;
            t.anchorMin = new Vector2(t.anchorMin.x + t.offsetMin.x / pt.rect.width, t.anchorMin.y + t.offsetMin.y / pt.rect.height);
            t.anchorMax = new Vector2(t.anchorMax.x + t.offsetMax.x / pt.rect.width, t.anchorMax.y + t.offsetMax.y / pt.rect.height);
            t.offsetMin = t.offsetMax = new Vector2(0, 0);
        }

        private void SetAnschorToUp(RectTransform t)
        {
            RectTransform pt = t.parent as RectTransform;
            float length = t.rect.height;
            Debug.Log(length);
            if (t == null || pt == null)
                return;

            t.anchorMin = new Vector2(t.anchorMin.x + t.offsetMin.x / pt.rect.width, t.anchorMin.y + t.offsetMin.y / pt.rect.height);
            t.anchorMax = new Vector2(t.anchorMax.x + t.offsetMax.x / pt.rect.width, t.anchorMax.y + t.offsetMax.y / pt.rect.height);

            t.offsetMin = t.offsetMax = new Vector2(0, 0);
            //t.anchorMin = new Vector2(t.anchorMin.x, t.anchorMax.y);
            //t.offsetMax = new Vector2(0, 0);
            //t.offsetMin = new Vector2(0, -length);
        }
    }
}