using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AuxiliarySkillSystom
{
    public class AuxiliarySkillScurry : AuxiliarySkillBase
    {
        private GameObject _operiterObject;

        public AuxiliarySkillScurry(GameObject ga) {

            _auxiliarySkillName = "疾跑";
            _auxiliarySkillDescription = "100秒CD：增加30%移动速度持续10秒";
        }

        public override void OperationSkillRelease()
        {
            throw new NotImplementedException();
        }
    }
}
