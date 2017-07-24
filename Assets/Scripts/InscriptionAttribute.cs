using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class InscriptionAttribute  {
    /// <summary>
    /// 属性名称
    /// </summary>
    private  string _attributeName;

    /// <summary>
    /// 属性的值类型
    /// </summary>
    private  AttributeValue _valueType;

    /// <summary>
    /// 属性值
    /// </summary>
    private  float _attributeValue;

    public string attributeName {

    get {
            return _attributeName;
        }
        set {
            this._attributeName = value;
        }
    }

    public AttributeValue valueType {
        get
        {
            return _valueType;
        }
        set {
            this._valueType = value;
        }
    }

    public float attribueValue {
        get
        {
            return _attributeValue;
        }
        set {
            this._attributeValue = value;
        }
    }
    
}
