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

        private float _tenacity;
        /// <summary>
        /// 韧性
        /// </summary>
        public float tenacity
        {
            get { return _tenacity; }
            set { _tenacity = value; }
        }


        private float _recoveBlood;
        /// <summary>
        /// 每5秒回血
        /// </summary>
        public float recoveBlood
        {
            get { return _recoveBlood; }
            set { _recoveBlood = value; }
        }

        private float _recoveMagic;
        /// <summary>
        /// 每5秒回蓝
        /// </summary>
        public float recoveMagic
        {
            get { return _recoveMagic; }
            set { _recoveMagic = value; }
        }
    }
}