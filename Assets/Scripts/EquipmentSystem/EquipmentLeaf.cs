using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EquipmentSystem
{
    [System.Serializable]
    public class EquipmentLeaf : BaseEquipment
    {
        public override void AddChildEquipment(BaseEquipment baseEquipment)
        {
            //Debug.Log(1);
        }

        public override List<BaseEquipment> GetChildEquipmet()
        {
            return new List<BaseEquipment>();
        }

        public override void RemoveChildEquipment(BaseEquipment baseEquipment)
        {
            //Debug.Log(2);
        }

        public override void SetInitiativeSkill()
        {
            //Debug.Log(2);
        }

        public override void SetPassiveSkill()
        {
            //Debug.Log(2);
        }

    }
}