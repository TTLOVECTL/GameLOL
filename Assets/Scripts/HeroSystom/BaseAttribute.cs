using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HeroSystem
{
    /// <summary>
    /// 英雄的基础属性
    /// </summary>
    public class BaseAttribute
    {
        /// <summary>
        /// 初始最大生命值
        /// </summary>
        private float _baseLife;

        public float baseLife
        {
            get { return _baseLife; }
            set { this._baseLife = value; }
        }

        /// <summary>
        /// 初始最大法力值
        /// </summary>
        private float _baseMagic;

        public float baseMagic
        {
            get { return _baseMagic; }
            set { _baseMagic = value; }
        }

        /// <summary>
        /// 物理攻击
        /// </summary>
        private float _physicalAttack;

        public float physicalAttack
        {
            get { return _physicalAttack; }
            set { _physicalAttack = value; }
        }

        /// <summary>
        /// 法术攻击
        /// </summary>
        private float _magicAttack;

        public float magicAttack
        {
            get { return _magicAttack; }
            set { _magicAttack = value; }
        }

        /// <summary>
        /// 法术防御
        /// </summary>
        private float _magicDefense;

        public float magicDefense
        {
            get { return _magicDefense; }
            set { _magicDefense = value; }
        }

        /// <summary>
        /// 物理防御
        /// </summary>
        private float _physicalDefense;

        public float physicalDefense
        {
            get { return _physicalDefense; }
            set { _physicalDefense = value; }
        }
    }
}