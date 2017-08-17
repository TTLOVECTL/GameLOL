using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HeroSystem.BaseHeroSystem
{
    public class HeroTouchController : MonoBehaviour
    {
        public GameObject playerObject;
        public BaseHeroController baseHeroController;

        private void Start()
        {
        }

        /// <summary>
        /// 脚本激活时调用
        /// </summary>
        private void OnEnable()
        {
            EasyJoystick.On_JoystickMove += On_JoystickMove;
            EasyJoystick.On_JoystickMoveEnd += On_JoystickMoveEnd;
            EasyButton.On_ButtonUp += On_ButtonUp;
        }

        /// <summary>
        /// 脚本销毁时调用
        /// </summary>
        private void OnDestroy()
        {
            EasyJoystick.On_JoystickMove -= On_JoystickMove;
            EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
            EasyButton.On_ButtonUp -= On_ButtonUp;
        }

        /// <summary>
        /// 脚本被隐藏时调用
        /// </summary>
        private void OnDisable()
        {
            EasyJoystick.On_JoystickMove -= On_JoystickMove;
            EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
            EasyButton.On_ButtonUp -= On_ButtonUp;
        }

        /// <summary>
        /// 事件绑定函数
        /// </summary>
        /// <param name="move"></param>
        void On_JoystickMove(MovingJoystick move)
        {
            baseHeroController.OnRun();
            float angle = move.Axis2Angle(true);
            playerObject.transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
            playerObject.transform.Translate(Vector3.forward * move.joystickValue.magnitude * Time.deltaTime);

        }

        void On_JoystickMoveEnd(MovingJoystick move)
        {
            baseHeroController.OnIdle();
        }

        void On_ButtonUp(string buttonName)
        {
            if (buttonName == "技能1")
            {
                baseHeroController.OnOneSkill();
            }
            else if (buttonName == "技能2")
            {
                baseHeroController.OnTwoSkill();
            }
            else if (buttonName == "技能3")
            {
                baseHeroController.OnThreeSkill();
            }
            else if (buttonName == "普攻")
            {
                baseHeroController.OnAttack();
            }
            else if (buttonName == "召唤师技能")
            {
                
            }
            else if (buttonName == "回城")
            {

            }
            else if (buttonName == "回血")
            {
                //移动控制
            }
        }
    }
}