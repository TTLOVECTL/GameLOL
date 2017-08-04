using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EquipmentSystem;
namespace EquipmentSystem.UI
{
    public class ChooseEquipmentSetting : MonoBehaviour
    {
        private static ChooseEquipmentSetting instance = null;

        private void Awake()
        {
            if (instance == null) {
                instance = this;
            }
        }

        public static ChooseEquipmentSetting Instance{
            get {
                return instance;
            }
        }

        public List<EquipmentLeaf> smallEquipmentList=null;

        public List<EquipmentComponent> middleEquipmentList = null;

        public List<EquipmentComponent> bigEquipmentList = null;

        public void OnInitEquitmentList(int searchId) {
            SearchType searchType = (SearchType)searchId;
            smallEquipmentList = EquipmentFactory.Instance.GetSmallEquipmentBySearchType(searchType);
            bigEquipmentList = EquipmentFactory.Instance.GetBigEquipmentBySerchType(searchType);
            middleEquipmentList = EquipmentFactory.Instance.GetMiddleEquipmentBySearchType(searchType);
            EquipmentUIResourceManage.Instance.EquipmentPagePanel.SendMessage("OnSerchEquipment");
        }

        private void Start()
        {
            OnInitEquitmentList((int)SearchType.ATTACK);
        }
    }
}
