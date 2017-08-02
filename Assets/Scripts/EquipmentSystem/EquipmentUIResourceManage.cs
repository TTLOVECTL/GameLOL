using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUIResourceManage : MonoBehaviour {
    private static EquipmentUIResourceManage instance=null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static EquipmentUIResourceManage Instance {
        get {
            return instance;
        }
    }

    /// <summary>
    /// 装备显示面板
    /// </summary>
    public GameObject EquipmentPagePanel;

    public GameObject EquipmentAttributePabel;

    /// <summary>
    /// 装备实例化物体
    /// </summary>
    public GameObject EquipmentInstantiateObj;

    /// <summary>
    ///装备面板中放置所有装备的物体
    /// </summary>
    public GameObject EquipmentPageContent;

    /// <summary>
    /// 装备面板实例化文字物体
    /// </summary>
    public GameObject EquipmentInstantiateTextObj;
}
