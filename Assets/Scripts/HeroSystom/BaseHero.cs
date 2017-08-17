using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace HeroSystem
{
    public class BaseHero
    {
        
        private int _heroId;
        /// <summary>
        /// 英雄ID
        /// </summary>
        public int heroId {
            get { return _heroId; }
            set { this._heroId = value; }
        }

        private string _heroName;
        /// <summary>
        /// 英雄名称
        /// </summary>
        public string heroName {
            get { return _heroName; }
            set { this._heroName = value; }
        }

        private int _heroGoldPrice;
        /// <summary>
        /// 英雄金币价格
        /// </summary>
        public int heroGoldPrice {
            get { return _heroGoldPrice; }
            set { this.heroGoldPrice = value; }
        }

        private int _heroCouponsPrice;
        /// <summary>
        /// 英雄点券价格
        /// </summary>
        public int heroCouponsPrice {
            get { return _heroCouponsPrice; }
            set { this.heroGoldPrice = value; }
        }

        private Sprite _herHeadoortrait;
        /// <summary>
        /// 英雄头像
        /// </summary>
        public Sprite herHeadoortrait {
            get { return _herHeadoortrait; }
            set { this._herHeadoortrait = value; }
        }

        private Sprite _heroImage;
        /// <summary>
        /// 英雄图片
        /// </summary>
        public Sprite heroImage {
            get { return _heroImage; }
            set { this._heroImage = value; }
        }

        private List<Sprite> _heroSkinImage;
        /// <summary>
        /// 英雄皮肤图片
        /// </summary>
        public List<Sprite> heroSkinImage {
            set { this._heroSkinImage = value; }
            get { return _heroSkinImage; }
        }

        private List<HeroPositioning> _heroPositioning;
        /// <summary>
        /// 英雄的定位
        /// </summary>
        public List<HeroPositioning> heroPostioning {
            get { if (_heroPositioning == null) {
                    _heroPositioning = new List<HeroPositioning>();
                }
                return _heroPositioning;
            }
            set { this._heroPositioning = value; }
        }

        private string _heroicBackground;
        /// <summary>
        /// 英雄背景
        /// </summary>
        public string heroicBackground {
             get { return _heroicBackground; }
            set { this._heroicBackground = value; }
        }

        private BaseAttribute _baseAttribute=null;
        /// <summary>
        ///英雄基础属性
        /// </summary>
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

        private AttackAttribute _attackAttribute=null;
        /// <summary>
        /// 英雄的攻击属性
        /// </summary>
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

        private DefenseAttribute _defenseAttribute=null;
        /// <summary>
        /// 英雄的防御属性
        /// </summary>
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

        private List<GameObject> _heroModles;
        /// <summary>
        /// 英雄模型
        /// </summary>
        public List<GameObject> heroModles {
            set { this._heroModles = value; }
            get { return _heroModles; }
        }

    }
}