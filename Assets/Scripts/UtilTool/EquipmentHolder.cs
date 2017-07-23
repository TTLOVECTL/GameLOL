using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EquipmentSystem;

[System.Serializable]
public class EquipmentHolder :ScriptableObject {
    public string description = "存储所有的装备信息";
    public List<EquipmentLeaf> equipmentLeaf;
    public List<EquipmentComponent> equipmentComponent;

    public BaseEquipment GetEquipmentByID (int equipmetId){
        foreach (BaseEquipment leaf in equipmentLeaf) {
            if (leaf.equipmentId == equipmetId) {
                return leaf;
            }
        }

        foreach (BaseEquipment componment in equipmentComponent) {
            if (componment.equipmentId == equipmetId) {
                return componment;
            }
        }

        return null;
    }

    public List<BaseEquipment> GetEquipmentBySearchID(SearchType searchType) {
        List<BaseEquipment> equipmentList = new List<BaseEquipment>();
        foreach (BaseEquipment leaf in equipmentLeaf)
        {
            if (leaf.seaechType == searchType)
            {
                equipmentList.Add(leaf);
            }
        }

        foreach (BaseEquipment componment in equipmentComponent)
        {
            if (componment.seaechType == searchType)
            {
                equipmentList.Add(componment);
            }
        }
        return equipmentList;
    }

    public List<BaseEquipment> GetEquipmentByType(EqunipmentType type) {
        List<BaseEquipment> equipmentList = new List<BaseEquipment>();
        switch (type) {
            case EqunipmentType.SMALL:
                foreach (BaseEquipment ba in equipmentLeaf)
                {
                    equipmentList.Add(ba);
                }
                break;
            case EqunipmentType.MIDDLE:
            case EqunipmentType.BIG:
                foreach (BaseEquipment ba in equipmentComponent)
                {
                    if (ba.equipmentType == type)
                    {
                        equipmentList.Add(ba);
                    }
                }
                break;

        }
        return equipmentList;
    }


}
