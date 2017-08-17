using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BaseHeroController  {

    /// <summary>
    /// 英雄1技能
    /// </summary>
    void OnOneSkill();

    /// <summary>
    /// 英雄2技能
    /// </summary>
    void OnTwoSkill();

    /// <summary>
    /// 英雄3技能
    /// </summary>
    void OnThreeSkill();

    /// <summary>
    /// 英雄普通攻击
    /// </summary>
    void OnAttack();

    /// <summary>
    /// 英雄死亡
    /// </summary>
    void OnDie();

    /// <summary>
    /// 英雄移动
    /// </summary>
    void OnRun();

    /// <summary>
    /// 英雄待机状态
    /// </summary>
    void OnIdle();
}
