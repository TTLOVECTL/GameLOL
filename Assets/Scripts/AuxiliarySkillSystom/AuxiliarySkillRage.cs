using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AuxiliarySkillSystom
{

    public class AuxiliarySkillRage : AuxiliarySkillBase
    {
        public AuxiliarySkillRage() {
            _auxiliarySkillName = "狂暴";
            _auxiliarySkillDescription = "60秒CD:增加攻击速度60%，并增加物理攻击力10%，持续5秒";
        }

        public override void OperationSkillRelease()
        {
            throw new NotImplementedException();
        }
    }
}
