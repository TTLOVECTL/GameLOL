using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EquipmentSystem {

    public class EquipmentComponent : BaseEquipment{

        private List<BaseEquipment> equipmentList = new List<BaseEquipment>();

        public override void AddChildEquipment(BaseEquipment baseEquipment)
        {
            equipmentList.Add(baseEquipment);
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
            throw new NotImplementedException();
        }

        public override void SetPassiveSkill()
        {
            throw new NotImplementedException();
        }
    }
}