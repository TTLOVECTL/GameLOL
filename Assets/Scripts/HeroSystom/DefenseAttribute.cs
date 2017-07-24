using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HeroSystem
{
    /// <summary>
    /// 人物角色的防御属性
    /// </summary>
    public class DefenseAttribute
    {

        /// <summary>
        /// 韧性
        /// </summary>
        private float _tenacity;

        public float tenacity
        {
            get { return _tenacity; }
            set { _tenacity = value; }
        }

        /// <summary>
        /// 每5秒回血
        /// </summary>
        private int _recoveBlood;

        public int recoveBlood
        {
            get { return _recoveBlood; }
            set { _recoveBlood = value; }
        }

        /// <summary>
        /// 每5秒回蓝
        /// </summary>
        private int _recoveMagic;

        public int recoveMagic
        {
            get { return _recoveMagic; }
            set { _recoveMagic = value; }
        }
    }
}