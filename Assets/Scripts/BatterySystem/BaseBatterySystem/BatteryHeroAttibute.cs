using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HeroSystem;
using AuxiliarySkillSystom;
using InscriptionSystem;

namespace BatterySystem.BatteryHeroSystem
{
    public class BaseBatteryAttibute{

        private static BaseBatteryAttibute _instance=null;

        private BaseBatteryAttibute() { }
        
        public static BaseBatteryAttibute Instance {
            get {
                if (_instance == null) {
                    _instance = new BaseBatteryAttibute();
                }
                return _instance;
            }
        }

        /// <summary>
        /// 英雄Id
        /// </summary>
        public int heroId;

        /// <summary>
        /// 英雄名称
        /// </summary>
        public string heroName;

        /// <summary>
        /// 当前生命值
        /// </summary>
        public int currentLifeValue;
        /// <summary>
        /// 当前魔法值
        /// </summary>
        public int currentMegicValue;

        /// <summary>
        /// 基础属性
        /// </summary>
        public BaseAttribute baseAttibute;

        /// <summary>
        /// 攻击属性
        /// </summary>
        public AttackAttribute attackAttibute;

        /// <summary>
        /// 防御属性
        /// </summary>
        public DefenseAttribute defenseAttibute;

        /// <summary>
        /// 召唤师技能
        /// </summary>
        public AuxiliarySkillBase auxiliarySkillBase;

        /// <summary>
        /// 初始化英战斗属性
        /// </summary>
        /// <param name="baseHero"></param>
        /// <param name="inscriptionPage"></param>
        public void InitBatteryAttibute(BaseHero baseHero, InscriptionPage inscriptionPage) {
            baseAttibute = CopyTool.DeepCopy<BaseAttribute>(baseHero.baseAttribute);
            attackAttibute = CopyTool.DeepCopy<AttackAttribute>(baseHero.attackAttribute);
            defenseAttibute = CopyTool.DeepCopy<DefenseAttribute>(baseHero.defenseAttribute);
            InitInscriptionAttibute(inscriptionPage);
        }

        /// <summary>
        /// 将符文属性加到英雄的战斗属性中
        /// </summary>
        /// <param name="inscriptionPage"></param>
        private  void InitInscriptionAttibute(InscriptionPage inscriptionPage) {
            inscriptionPage.CalculatedAttribute();
            foreach (KeyValuePair<int,InscriptionAttribute> item in inscriptionPage.inscriptionAttribute) {
                switch ((BatteryAttributeType)item.Key) {
                    case BatteryAttributeType.MEGIC_ATTACK:
                        baseAttibute.magicAttack += item.Value._attributeValue;
                        break;
                    case BatteryAttributeType.ATTACK_SPEED:
                        attackAttibute.cttackSpeed += item.Value._attributeValue;
                        break;
                    case BatteryAttributeType.COOL_REDUCE:
                        attackAttibute.coolReduce += item.Value._attributeValue;
                        break;
                    case BatteryAttributeType.CRITICAL_CHANGE:
                        attackAttibute.criticalChance += item.Value._attributeValue;
                        break;
                    case BatteryAttributeType.CRITICAL_EFFECT:
                        attackAttibute.criticalEffect += item.Value._attributeValue;
                        break;
                    case BatteryAttributeType.MAX_BLUE:
                        baseAttibute.baseLife += item.Value._attributeValue;
                        break;
                    case BatteryAttributeType.MAX_LIFE:
                        baseAttibute.baseMagic += item.Value.attribueValue;
                        break;
                    case BatteryAttributeType.MEGIC_DEFENCE:
                        baseAttibute.magicDefense += item.Value.attribueValue;
                        break;
                    case BatteryAttributeType.MEGIC_THROUGH:
                        attackAttibute.magicPenetration+= item.Value.attribueValue;
                        break;
                    case BatteryAttributeType.MEGIC_VAMPIRE:
                        attackAttibute.magicHemophagia += item.Value.attribueValue;
                        break;
                    case BatteryAttributeType.MOVE_SPEED:
                        attackAttibute.moveSpeed += item.Value.attribueValue;
                        break;
                    case BatteryAttributeType.PHYSIC_ATTACK:
                        baseAttibute.physicalAttack += item.Value.attribueValue;
                        break;
                    case BatteryAttributeType.PHYSIC_DEFENCE:
                        baseAttibute.physicalDefense += item.Value.attribueValue;
                        break;
                    case BatteryAttributeType.PHYSIC_THROUGH:
                        attackAttibute.physicalPenetration += item.Value.attribueValue;
                        break;
                    case BatteryAttributeType.PHYSIC_VANPIRE:
                        attackAttibute.chysicalHemophagia += item.Value.attribueValue;
                        break;
                    case BatteryAttributeType.RECOVE_BLOOD:
                        attackAttibute.coolReduce += item.Value.attribueValue;
                        break;
                    case BatteryAttributeType.RECOVE_BLUE:
                        defenseAttibute.recoveMagic += item.Value.attribueValue;
                        break;

                }
            }
        }
    }
}
