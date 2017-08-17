using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EquipmentSystem;

namespace EquipmentSystem.UI
{
    public class EquipmentButton : MonoBehaviour
    {
        public static GameObject currentEquipmentButton;

        public int equipemntId;

        public SearchType searchType;

        public EqunipmentType equipmentType;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnButtonClick() {
            currentEquipmentButton = this.gameObject;
            EquipmentUIResourceManage.Instance.EquipmentAttributePabel.SendMessage("OnReciveMessgaeEquipmentButton");
            EquipmentUIResourceManage.Instance.EquipmentPagePanel.SendMessage("OnDrawConnection");

        }
    }
}