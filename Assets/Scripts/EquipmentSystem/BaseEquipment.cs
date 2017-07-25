using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EquipmentSystem {
    /// <summary>
    /// 
    /// </summary>
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
        /// 装备价格
        /// </summary>
        public int equipmentPrice;

        /// <summary>
        /// 装备图标
        /// </summary>
        public Sprite equipmentIcor;

        /// <summary>
        /// 装备属性
        /// </summary>
        public List<EquipmentAttribute> equipmentAttribute;

        /// <summary>
        /// 被动技能描述
        /// </summary>
        public string PassiveSkill;

        /// <summary>
        /// 主动技能描述
        /// </summary>
        public string InitiativeSkill;

        public abstract void AddChildEquipment(BaseEquipment baseEquipment);

        public abstract void RemoveChildEquipment(BaseEquipment baseEquipment);

        public abstract void SetPassiveSkill();

        public abstract void SetInitiativeSkill();
    }
}