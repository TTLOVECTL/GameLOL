using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AuxiliarySkillSystom
{
    public class AuxiliarySkillPurify : AuxiliarySkillBase
    {
        public override void OperationSkillRelease()
        {
            throw new NotImplementedException();
        }//净化：120秒CD，解除自身所有负面和控制效果（支配效果除外）并免疫控制持续1.5秒
    }
}