using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace InscriptionSystem
{
    [System.Serializable]
    /// <summary>
    /// 符文属性属性值
    /// </summary>
    public class InscriptionAttribute
    {
        public  int _attributeId;

        public   string _attributeName;

        public AttributeValue _valueType;

        public  float _attributeValue;

        /// <summary>
        /// 属性名称
        /// </summary>
        public string attributeName
        {

            get
            {
                return _attributeName;
            }
            set
            {
                this._attributeName = value;
            }
        }

        /// <summary>
        /// 属性的值类型
        /// </summary>
        public AttributeValue valueType
        {
            get
            {
                return _valueType;
            }
            set
            {
                this._valueType = value;
            }
        }

        /// <summary>
        /// 属性值
        /// </summary>
        public float attribueValue
        {
            get
            {
                return _attributeValue;
            }
            set
            {
                this._attributeValue = value;
            }
        }

        /// <summary>
        /// 属性ID
        /// </summary>
        public int attributeId
        {
            get { return _attributeId; }
            set { this._attributeId = value; }
        }
    }
}