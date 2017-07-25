using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EquipmentSystem
{
    public class EquipmentColumn
    {
        private SortedDictionary<int, BaseEquipment> _equipments = new SortedDictionary<int, BaseEquipment>();

        /// <summary>
        /// 用于存储装备的词典
        /// </summary>
        public SortedDictionary<int, BaseEquipment> equipments
        {
            get
            {
                return _equipments;
            }
        }

        /// <summary>
        /// 向装备栏中添加装备
        /// </summary>
        /// <param name="equipment"></param>
        public void AddEqupment(BaseEquipment equipment) {
            if (_equipments.Count < 6) {
                _equipments.Add(equipment.equipmentId,equipment);
            }
        }

        /// <summary>
        /// 从装备栏中移除装备
        /// </summary>
        /// <param name="equipmntId"></param>
        public void RemoveEquipment(int equipmntId) {
            if (_equipments.ContainsKey(equipmntId)) {
                _equipments.Remove(equipmntId);
            }
        }

        /// <summary>
        /// 检查是否包含指定Id的装备
        /// </summary>
        /// <param name="equipmentId"></param>
        /// <returns></returns>
        public bool CheckIsEquipment(int equipmentId) {
            if (_equipments.ContainsKey(equipmentId))
            {
                return true;
            }
            else {
                return false;
            }
        }

    }
}
