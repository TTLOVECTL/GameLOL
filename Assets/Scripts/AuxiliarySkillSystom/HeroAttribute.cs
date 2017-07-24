using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttribute : MonoBehaviour {

    private static HeroAttribute instance = null;

    void Start () {
        if (instance == null) {
            IninHeroData(1);
            instance = this;
        }
		
	}
    public static HeroAttribute Instance {
        get {
            return instance;
        }
    }

    /// <summary>
    /// 初始最大生命值
    /// </summary>
    protected int _baseLife;

    public int baseLife
    {
        get { return _baseLife; }
        set { this._baseLife = value; }
    }

    /// <summary>
    /// 初始最大法力值
    /// </summary>
    protected int _baseMagic;

    public int baseMagic
    {
        get { return _baseMagic; }
        set { _baseMagic = value; }
    }

    /// <summary>
    /// 物理攻击值
    /// </summary>
    protected int _physicalAttack;

    public int physicalAttack
    {
        get { return _physicalAttack; }
        set { _physicalAttack = value; }
    }

    /// <summary>
    /// 法术攻击
    /// </summary>
    protected int _magicAttack;

    public int magicAttack
    {
        get { return _magicAttack; }
        set { _magicAttack = value; }
    }

    /// <summary>
    /// 法术防御
    /// </summary>
    protected int _magicDefense;

    public int magicDefense
    {
        get { return _magicDefense; }
        set { _magicDefense = value; }
    }

    /// <summary>
    /// 物理防御
    /// </summary>
    protected int _physicalDefense;

    public int physicalDefense
    {
        get { return _physicalDefense; }
        set { _physicalDefense = value; }
    }

    /// <summary>
    /// 移动速度
    /// </summary>
    protected int _moveSpeed;

    public int moveSpeed
    {
        get { return _moveSpeed; }
        set { this._moveSpeed = value; }
    }

    /// <summary>
    /// 物理穿透
    /// </summary>
    protected int _physicalPenetration;

    public int physicalPenetration
    {
        get { return _physicalPenetration; }
        set { this._physicalPenetration = value; }
    }

    /// <summary>
    /// 法术穿透
    /// </summary>
    protected int _magicPenetration;

    public int magicPenetration
    {
        get { return _magicPenetration; }
        set { this._magicPenetration = value; }

    }
    /// <summary>
    /// 攻击速度
    /// </summary>
    protected float _attackSpeed;

    public float cttackSpeed
    {
        get { return _attackSpeed; }
        set { this._attackSpeed = value; }
    }

    /// <summary>
    ///暴击几率
    /// </summary>
    protected float _criticalChance;

    public float criticalChance
    {
        get { return _criticalChance; }
        set { this._criticalChance = value; }
    }

    /// <summary>
    /// 暴击效果
    /// </summary>
    protected float _criticalEffect;

    public float criticalEffect
    {
        get { return _criticalEffect; }
        set { this._criticalEffect = value; }
    }

    /// <summary>
    /// 物理吸血
    /// </summary>
    protected float _physicalHemophagia;

    public float chysicalHemophagia
    {
        set { this._physicalHemophagia = value; }
        get { return _physicalHemophagia; }
    }

    /// <summary>
    /// 法术吸血
    /// </summary>
    protected float _magicHemophagia;

    public float magicHemophagia
    {
        get { return _magicHemophagia; }
        set { this._magicHemophagia = value; }
    }

    /// <summary>
    /// 冷却缩减
    /// </summary>
    protected float _coolReduce;

    public float coolReduce
    {
        get { return _coolReduce; }

        set { this._coolReduce = value; }
    }

    /// <summary>
    /// 韧性
    /// </summary>
    protected float _tenacity;

    public float tenacity
    {
        get { return _tenacity; }
        set { _tenacity = value; }
    }

    /// <summary>
    /// 每5秒回血
    /// </summary>
    protected int _recoveBlood;

    public int recoveBlood
    {
        get { return _recoveBlood; }
        set { _recoveBlood = value; }
    }

    /// <summary>
    /// 每5秒回蓝
    /// </summary>
    protected int _recoveMagic;

    public int recoveMagic
    {
        get { return _recoveMagic; }
        set { _recoveMagic = value; }
    }

    /// <summary>
    /// 初始化英雄数据
    /// </summary>  
    private void IninHeroData(int heroId) {

    }
}