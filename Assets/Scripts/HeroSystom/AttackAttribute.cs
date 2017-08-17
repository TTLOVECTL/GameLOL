using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HeroSystem
{
    /// <summary>
    /// 人物角色的攻击属性
    /// </summary>
    public class AttackAttribute
    {

        private float _moveSpeed;
        /// <summary>
        /// 移动速度
        /// </summary>
        public float moveSpeed
        {
            get { return _moveSpeed; }
            set { this._moveSpeed = value; }
        }


        private float _physicalPenetration;
        /// <summary>
        /// 物理穿透
        /// </summary>
        public float physicalPenetration
        {
            get { return _physicalPenetration; }
            set { this._physicalPenetration = value; }
        }

        private float _magicPenetration;
        /// <summary>
        /// 法术穿透
        /// </summary>
        public float magicPenetration
        {
            get { return _magicPenetration; }
            set { this._magicPenetration = value; }

        }

        private float _attackSpeed;
        /// <summary>
        /// 攻击速度
        /// </summary>
        public float cttackSpeed
        {
            get { return _attackSpeed; }
            set { this._attackSpeed = value; }
        }


        private float _criticalChance;
        /// <summary>
        ///暴击几率
        /// </summary>
        public float criticalChance
        {
            get { return _criticalChance; }
            set { this._criticalChance = value; }
        }


        private float _criticalEffect;
        /// <summary>
        /// 暴击效果
        /// </summary>
        public float criticalEffect
        {
            get { return _criticalEffect; }
            set { this._criticalEffect = value; }
        }

        
        private float _physicalHemophagia;
         /// <summary>
        /// 物理吸血
        /// </summary>
        public float chysicalHemophagia
        {
            set { this._physicalHemophagia = value; }
            get { return _physicalHemophagia; }
        }

        
        private float _magicHemophagia;
        /// <summary>
        /// 法术吸血
        /// </summary>
        public float magicHemophagia
        {
            get { return _magicHemophagia; }
            set { this._magicHemophagia = value; }
        }

       
        private float _coolReduce;
        /// <summary>
        /// 冷却缩减
        /// </summary>
        public float coolReduce
        {
            get { return _coolReduce; }

            set { this._coolReduce = value; }
        }

        
        private string _attrackScale;
        /// <summary>
        /// 攻击范围
        /// </summary>
        public string attrackScale
        {
            get { return _attrackScale; }
            set { this._attrackScale = value; }
        }
    }
}