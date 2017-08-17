using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EquipmentSystem;
using UnityEngine.UI;
namespace EquipmentSystem.UI {
    public class SyntheticPathPanel : MonoBehaviour {

        public GameObject contentTreeObject;

        public GameObject contentTableObject;

        public GameObject InstanceTableObject;

        public GameObject instacneTreeObject;

        private float treeObjectWidth;

        private float treeObjectHeight;

        private float tableObjectWidth;

        private float tableObjectHeight;

        public GameObject postObkect;

        public GameObject PosObject;
        // Use this for initialization
        void Awake() {
            tableObjectHeight = postObkect.GetComponent<RectTransform>().rect.height;
            tableObjectWidth = postObkect.GetComponent<RectTransform>().rect.width;
            treeObjectWidth = PosObject.GetComponent<RectTransform>().rect.width;
        }

        /// <summary>
        /// 实例化合成面板的选择面板内容
        /// </summary>
        /// <param name="baseEquiment"></param>
        private void InstanceTableList(BaseEquipment baseEquiment) {
            int length = baseEquiment.parientEquipentList.Count;
            if (length > 0) {
                float buttonWidth = tableObjectHeight;
                float width = buttonWidth * length + 2 * (length + 1);
               // Debug.Log(width);
                if (width < tableObjectWidth) {
                    width = tableObjectWidth;
                }
                //Debug.Log(width);
                contentTableObject.GetComponent<RectTransform>().sizeDelta=new Vector2(width,0);
                int count = 0;
                foreach (int a in baseEquiment.parientEquipentList) {
                    BaseEquipment equipemnt = EquipmentFactory.Instance.GetEquipmemtByID(a);
                    if (equipemnt != null) {
                        GameObject ga = Instantiate(InstanceTableObject) as GameObject;
                        SyntheyicTableButton button = ga.GetComponent<SyntheyicTableButton>();
                        ga.GetComponent<Image>().sprite = equipemnt.equipmentIcor;
                        button.equipmentId = equipemnt.equipmentId;
                        button.equipemtType = equipemnt.equipmentType;

                        ga.transform.SetParent(contentTableObject.transform);
                        ga.GetComponent<RectTransform>().sizeDelta = new Vector2(buttonWidth,0);
                        ga.GetComponent<RectTransform>().localPosition = new Vector2(count*(buttonWidth+2)+2+buttonWidth/2,-buttonWidth/2);
                        count++;
                    }
                }
            }
        }

        private void InstanceTreeList(BaseEquipment baseEquipment) {
            float buttonWidth = treeObjectWidth / 9;
            //Debug.Log(buttonWidth);
            float height = buttonWidth * 6;
            contentTreeObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0,height);
            GameObject ga = Instantiate(instacneTreeObject) as GameObject;
            ga.transform.SetParent(contentTreeObject.transform);
            ga.GetComponent<Image>().sprite = baseEquipment.equipmentIcor;
            ga.GetComponent<RectTransform>().sizeDelta = new Vector2(-(treeObjectWidth-buttonWidth),buttonWidth);
            ga.GetComponent<RectTransform>().localPosition = new Vector3(treeObjectWidth/2,-buttonWidth);
            if (baseEquipment.equipmentType == EqunipmentType.SMALL) {
                return;
            }
            EquipmentComponent comp = (EquipmentComponent)baseEquipment;
            if (comp.equipmentCompmenTList.Count > 0)
            {
                
            }
            
        }


        public void ReciveMessageUp(BaseEquipment a) {
            InstanceTableList(a);
            InstanceTreeList(a);
        }

        public void OnCloseSynthPathPanel() {
            this.gameObject.SetActive(false);
        }
    }
}