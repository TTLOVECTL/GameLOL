using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AuxiliarySkillSystom
{
    public class AuxiliarySkillDiscipline : AuxiliarySkillBase
    {
        private GameObject _operiterObject;

        public AuxiliarySkillDiscipline(GameObject ga) {
            _auxiliarySkillName = "惩戒";
            _auxiliarySkillDescription = "30秒CD：对身边的野怪和小兵造成800点的真实伤害并眩晕1秒。";
        }

        public override void OperationSkillRelease()
        {
            throw new NotImplementedException();
        }

       
    }
}