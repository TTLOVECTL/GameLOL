using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
namespace HeroSystom
=======
namespace HeroSystem
>>>>>>> fde55267e4d35e89e5654320a92b7253cbb7f9ac
{
    public class BaseHero
    {
        /// <summary>
        /// 英雄ID
        /// </summary>
        private int _heroId;

        private string _heroName;

        /// <summary>
        ///英雄基础属性
        /// </summary>
        private BaseAttribute _baseAttribute=null;

        public BaseAttribute baseAttribute {
            get {
                if (_attackAttribute == null) {
                    _baseAttribute = new BaseAttribute();
                }
                return _baseAttribute;
            }

            set{
                this._baseAttribute = value;
            }
        }

        /// <summary>
        /// 英雄的攻击属性
        /// </summary>
        private AttackAttribute _attackAttribute=null;

        public AttackAttribute attackAttribute
        {
            get
            {
                if (_attackAttribute == null)
                {
                    _attackAttribute = new AttackAttribute();
                }
                return _attackAttribute;
            }
            set {
                this._attackAttribute = value;
            }
        }

        /// <summary>
        /// 英雄的防御属性
        /// </summary>
        private DefenseAttribute _defenseAttribute=null;

        public DefenseAttribute defenseAttribute
        {
            get
            {
                if (_defenseAttribute == null)
                {
                    _defenseAttribute = new DefenseAttribute();
                }
                return _defenseAttribute;
            }
            set {
                this._defenseAttribute = value;
            }
        }

    }
}