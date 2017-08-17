using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BatterySystem.BatteryHeroSystem
{
    /// <summary>
    /// 英雄属性类型
    /// </summary>
    public enum BatteryAttributeType
    {
        /// <summary>
        /// 无属性0
        /// </summary>
        NONE,

        /// <summary>
        /// 法术攻击1
        /// </summary>
        MEGIC_ATTACK,

        /// <summary>
        ///物理攻击 2
        /// </summary>
        PHYSIC_ATTACK,

        /// <summary>
        /// 法术防御3
        /// </summary>
        MEGIC_DEFENCE,

        /// <summary>
        /// 物理防御4
        /// </summary>
        PHYSIC_DEFENCE,

        /// <summary>
        /// 法术吸血5
        /// </summary>
        MEGIC_VAMPIRE,

        /// <summary>
        /// 物理吸血6
        /// </summary>
        PHYSIC_VANPIRE,

        /// <summary>
        /// 法术穿透7
        /// </summary>
        MEGIC_THROUGH,

        /// <summary>
        /// 物理穿透8
        /// </summary>
        PHYSIC_THROUGH,

        /// <summary>
        /// 冷却缩减9
        /// </summary>
        COOL_REDUCE,

        /// <summary>
        /// 攻击速度10
        /// </summary>
        ATTACK_SPEED,

        /// <summary>
        /// 最大生命值11
        /// </summary>
        MAX_LIFE,

        /// <summary>
        /// 暴击率12
        /// </summary>
        CRITICAL_CHANGE,

        /// <summary>
        /// 暴击效果13
        /// </summary>
        CRITICAL_EFFECT,

        /// <summary>
        /// 每五秒回血14
        /// </summary>
        RECOVE_BLOOD,

        /// <summary>
        /// 移速15
        /// </summary>
        MOVE_SPEED,

        /// <summary>
        /// 最大蓝16
        /// </summary>
        MAX_BLUE,

        /// <summary>
        /// 每五秒回蓝17
        /// </summary>
        RECOVE_BLUE


    }
}
