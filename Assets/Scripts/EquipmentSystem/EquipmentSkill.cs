using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EquipmentSystem
{
    [System.Serializable] 
    public class EquipmentSkill
    {
        /// <summary>
        /// 武器技能ID
        /// </summary>
        public int skillID;

        /// <summary>
        /// 武器技能名称
        /// </summary>
        public string skillName;

        /// <summary>
        /// 武器技能描述
        /// </summary>
        public string skillDescription;
    }
}
