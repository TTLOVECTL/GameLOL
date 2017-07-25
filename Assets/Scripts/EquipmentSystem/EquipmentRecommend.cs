using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EquipmentSystem
{
    public class EquipmentRecommend
    {
        private SortedDictionary<int, BaseEquipment> _recommendList = new SortedDictionary<int, BaseEquipment>();

        private SortedDictionary<int, BaseEquipment> _middleEquipmentList = new SortedDictionary<int, BaseEquipment>();

        private SortedDictionary<int, BaseEquipment> _smallEquipmentList = new SortedDictionary<int, BaseEquipment>();

        public SortedDictionary<int, BaseEquipment> recommendList
        {
            get
            {
                return _recommendList;
            }
        }

        public SortedDictionary<int, BaseEquipment> middleEquipmentList {
            get {
                return _middleEquipmentList;
            }
        }

        public SortedDictionary<int, BaseEquipment> smallEquipmentList {
            get {
                return _smallEquipmentList;
            }
        }

        public EquipmentRecommend() { }

        public EquipmentRecommend(int a) { }

        public void AddRecommendEquipment(BaseEquipment baseEquipment)
        {
            BaseEquipment ecop = CopyTool.DeepCopy<BaseEquipment>(baseEquipment);
            if (_recommendList.ContainsKey(ecop.equipmentId))
                _recommendList.Add(ecop.equipmentId, ecop);
        }

        public void RemoveRecommendEquipment(int equipmentID)
        {
            if (_recommendList.ContainsKey(equipmentID))
            {
                _recommendList.Remove(equipmentID);
            }
        }

        public void CalculateEquipment()
        {
            if (_recommendList.Count <= 0)
            {
                return;
            }
            foreach (KeyValuePair<int, BaseEquipment> item in _recommendList)
            {
                List<BaseEquipment> baseList = item.Value.GetChildEquipmet();
                foreach (BaseEquipment baseEq in baseList)
                {
                    if (baseEq.equipmentType == EqunipmentType.MIDDLE && (!_middleEquipmentList.ContainsKey(baseEq.equipmentId)))
                        _middleEquipmentList.Add(baseEq.equipmentId, CopyTool.DeepCopy<BaseEquipment>(baseEq));
                    else if (baseEq.equipmentType == EqunipmentType.SMALL && (!_smallEquipmentList.ContainsKey(baseEq.equipmentId)))
                        _smallEquipmentList.Add(baseEq.equipmentId, CopyTool.DeepCopy<BaseEquipment>(baseEq));
                }
            }

            foreach (KeyValuePair<int, BaseEquipment> item in _middleEquipmentList)
            {
                List<BaseEquipment> baseList = item.Value.GetChildEquipmet();
                foreach (BaseEquipment baseEq in baseList)
                {
                    if (baseEq.equipmentType == EqunipmentType.SMALL && (!_smallEquipmentList.ContainsKey(baseEq.equipmentId)))
                        _smallEquipmentList.Add(baseEq.equipmentId, CopyTool.DeepCopy<BaseEquipment>(baseEq));
                }
            }

        }
    }
}