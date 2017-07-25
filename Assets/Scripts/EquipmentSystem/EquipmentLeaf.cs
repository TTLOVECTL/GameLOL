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
            throw new NotImplementedException();
        }

        public override void RemoveChildEquipment(BaseEquipment baseEquipment)
        {
            throw new NotImplementedException();
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