using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EquipmentSystem {

    [System.Serializable]
    public class EquipmentComponent : BaseEquipment{

        public List<BaseEquipment> equipmentList = new List<BaseEquipment>();

        public List<EquipmentLeaf> equipmentLeafList = new List<EquipmentLeaf>();

        public List<EquipmentComponent> equipmentCompmenTList = new List<EquipmentComponent>();

        public override void AddChildEquipment(BaseEquipment baseEquipment)
        {
            if (baseEquipment.equipmentType == EqunipmentType.SMALL)
            {
                equipmentLeafList.Add((EquipmentLeaf)baseEquipment);
            }
            else {
                equipmentCompmenTList.Add((EquipmentComponent)baseEquipment);
            }
        }

        public override List<BaseEquipment> GetChildEquipmet()
        {
            return equipmentList;
        }

        public override void RemoveChildEquipment(BaseEquipment baseEquipment)
        {
            if (equipmentList.Contains(baseEquipment))
            {
                equipmentList.Remove(baseEquipment);
            }
        }

        public override void SetInitiativeSkill()
        {
            //Debug.Log(1);
        }

        public override void SetPassiveSkill()
        {
            //Debug.Log(1);
        }
    }
}