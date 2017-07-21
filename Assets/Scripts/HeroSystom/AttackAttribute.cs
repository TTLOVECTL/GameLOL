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
        /// <summary>
        /// 移动速度
        /// </summary>
        private int _moveSpeed;

        public int moveSpeed
        {
            get { return _moveSpeed; }
            set { this._moveSpeed = value; }
        }

        /// <summary>
        /// 物理穿透
        /// </summary>
        private int _physicalPenetration;

        public int physicalPenetration
        {
            get { return _physicalPenetration; }
            set { this._physicalPenetration = value; }
        }

        /// <summary>
        /// 法术穿透
        /// </summary>
        private int _magicPenetration;

        public int magicPenetration
        {
            get { return _magicPenetration; }
            set { this._magicPenetration = value; }

        }
        /// <summary>
        /// 攻击速度
        /// </summary>
        private float _attackSpeed;

        public float cttackSpeed
        {
            get { return _attackSpeed; }
            set { this._attackSpeed = value; }
        }

        /// <summary>
        ///暴击几率
        /// </summary>
        private float _criticalChance;

        public float criticalChance
        {
            get { return _criticalChance; }
            set { this._criticalChance = value; }
        }

        /// <summary>
        /// 暴击效果
        /// </summary>
        private float _criticalEffect;

        public float criticalEffect
        {
            get { return _criticalEffect; }
            set { this._criticalEffect = value; }
        }

        /// <summary>
        /// 物理吸血
        /// </summary>
        private float _physicalHemophagia;

        public float chysicalHemophagia
        {
            set { this._physicalHemophagia = value; }
            get { return _physicalHemophagia; }
        }

        /// <summary>
        /// 法术吸血
        /// </summary>
        private float _magicHemophagia;

        public float magicHemophagia
        {
            get { return _magicHemophagia; }
            set { this._magicHemophagia = value; }
        }

        /// <summary>
        /// 冷却缩减
        /// </summary>
        private float _coolReduce;

        public float coolReduce
        {
            get { return _coolReduce; }

            set { this._coolReduce = value; }
        }

        /// <summary>
        /// 攻击访问
        /// </summary>
        private string _attrackScale;

        public string attrackScale
        {
            get { return _attrackScale; }
            set { this._attrackScale = value; }
        }
    }
}