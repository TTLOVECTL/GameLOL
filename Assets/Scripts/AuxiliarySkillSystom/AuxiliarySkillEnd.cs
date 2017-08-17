using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BatterySystem.BatteryHeroSystem;
namespace AuxiliarySkillSystom
{
    public class AuxiliarySkillEnd : AuxiliarySkillBase
    {
        private  GameObject _operiterObject;
        private float scale = 1f;

        public AuxiliarySkillEnd(GameObject ga) {
            _operiterObject = ga;
            _auxiliarySkillId = 2;
            _auxiliarySkillName = "终结";
            _auxiliarySkillDescription = "90秒CD：立即对身边敌军英雄造成其已损失生命值14%的真实伤害。";
            _coolingTime = 90;
        }

        public override void OperationSkillRelease()
        {
            foreach (GameObject item in BatteryConst.enemyList) {
                if (Vector3.Distance(_operiterObject.transform.position, item.transform.position) < scale) {
                   // item.
                }
            }
        }
    }
}
