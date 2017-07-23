using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EquipmentSystem {
   
    [System.Serializable]
    public abstract class BaseEquipment {
        /// <summary>
        /// 装备id
        /// </summary>
        public int equipmentId;

        /// <summary>
        /// 装备名称
        /// </summary>
        public string equipmentName;

        /// <summary>
        /// 装备分类
        /// </summary>
        public SearchType seaechType;
        /// <summary>
        /// 装备价格
        /// </summary>
        public int equipmentPrice;

        /// <summary>
        /// 装备图标
        /// </summary>
        public Sprite equipmentIcor;

        /// <summary>
        /// 装备类型
        /// </summary>
        public EqunipmentType equipmentType;

        /// <summary>
        /// 装备属性
        /// </summary>
        public List<EquipmentAttribute> equipmentAttribute;

        /// <summary>
        /// 装备的技能
        /// </summary>
        public List<EquipmentSkill> equipmentSkill;

        /// <summary>
        ///能有该装备合成的装备
        /// </summary>
        public List<int> parientEquipentList;

        public abstract void AddChildEquipment(BaseEquipment baseEquipment);

        public abstract void RemoveChildEquipment(BaseEquipment baseEquipment);

        public abstract List<BaseEquipment> GetChildEquipmet();

        public abstract void SetPassiveSkill();

        public abstract void SetInitiativeSkill();
    }
}