using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AuxiliarySkillSystom
{
    public class AuxiliarySkillFlash : AuxiliarySkillBase
    {

        private GameObject _operiterObject;

        public Vector3 _flashDirection;

        private float _moveDistance=5f;

        public AuxiliarySkillFlash(GameObject ga)
        {
            _operiterObject = ga;
            _auxiliarySkillId = 1;
            _auxiliarySkillName = "闪现";
            _auxiliarySkillDescription = "120秒CD，向指定方向位移一段距离。";
            _coolingTime = 120;
        }

        public override void OperationSkillRelease()
        {
            Vector3 currentPos = _operiterObject.transform.position;
            float cosValue = (Vector3.Dot(Vector3.right, _flashDirection)) / (Vector3.Magnitude(Vector3.forward) * Vector3.Magnitude(_flashDirection));
            float sinValue = Mathf.Sqrt(1 - Mathf.Pow(cosValue, 2));
            float x = Mathf.Abs(cosValue * _moveDistance);
            float z = Mathf.Abs(sinValue * _moveDistance);
            Vector3 tartgetPos;
            if (_flashDirection.x >= 0 && _flashDirection.z >= 0)
            {
                tartgetPos = currentPos + new Vector3(x, 0, z);
            }
            else if (_flashDirection.x >= 0 && _flashDirection.z < 0)
            {
                tartgetPos = currentPos + new Vector3(x, 0, -z);
            }
            else if (_flashDirection.x < 0 && _flashDirection.z > 0)
            {
                tartgetPos = currentPos + new Vector3(-x, 0, z);
            }
            else
            {
                tartgetPos = currentPos + new Vector3(-x, 0, -z);
            }
           
            Vector3 direction = _operiterObject.transform.InverseTransformDirection(_flashDirection);

            float  flag = Vector3.Cross(Vector3.forward,Vector3.Normalize(direction)).y;

            Vector3 elureulerAngles = _operiterObject.transform.eulerAngles;

            float rotationAngles = Vector3.Angle(Vector3.forward, Vector3.Normalize(direction));

            Quaternion  targerRotation =Quaternion.Euler(elureulerAngles + new Vector3(0,flag*rotationAngles,0));

            _operiterObject.transform.position = tartgetPos;

            _operiterObject.transform.rotation = targerRotation;
        }
    }
}