using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AuxiliarySkillSystom
{
    public abstract class AuxiliarySkillBase
    {

        protected int _auxiliarySkillId;

        protected string _auxiliarySkillName;

        protected string _auxiliarySkillDescription;

        protected float _coolingTime;

        protected Sprite _auxiliarySkillIcon;

        public float _restTime = 0;

        public int auxiliarySkillId
        {
            get
            {
                return _auxiliarySkillId;
            }
        }

        public string auxiliarySkillName
        {
            get
            {
                return _auxiliarySkillName;
            }
        }

        public string auxiliarySkillDescription
        {
            get
            {
                return _auxiliarySkillDescription;
            }
        }

        public Sprite auxiliarySkillIcon
        {
            get
            {
                return _auxiliarySkillIcon;
            }
        }

        public float coolingTime
        {
            get
            {
                return _coolingTime;
            }
        }

        public abstract void OperationSkillRelease();
    }
}