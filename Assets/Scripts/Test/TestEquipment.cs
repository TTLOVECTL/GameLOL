using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using EquipmentSystem;

public class TestEquipment : MonoBehaviour {

	// Use this for initialization
	void Start () {
        readAsset();
	}

    private void readAsset()
    {
        EquipmentHolder ceh = AssetDatabase.LoadAssetAtPath<EquipmentHolder>("Assets/Assets/Equipment.asset");
        if (ceh == null)
        {
            return;
        }
        Debug.Log(ceh.GetEquipmentByID(1).equipmentName);
    }
}
