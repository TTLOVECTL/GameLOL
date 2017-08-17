using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HeroSystem.BaseHeroSystem
{
    public class HeroTouchController : MonoBehaviour
    {

        public BaseHeroController baseHeroController;

        private void Start()
        {
        }

        private void OnEnable()
        {
            EasyJoystick.On_JoystickMove += On_JoystickMove;
            EasyJoystick.On_JoystickMoveEnd += On_JoystickMoveEnd;
            EasyButton.On_ButtonUp += On_ButtonUp;
        }

        private void OnDestroy()
        {
            EasyJoystick.On_JoystickMove -= On_JoystickMove;
            EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
            EasyButton.On_ButtonUp -= On_ButtonUp;
        }

        private void OnDisable()
        {
            EasyJoystick.On_JoystickMove -= On_JoystickMove;
            EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
            EasyButton.On_ButtonUp -= On_ButtonUp;
        }

        void On_JoystickMove(MovingJoystick move)
        {
            baseHeroController.OnRun();
            float angle = move.Axis2Angle(true);
            transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
            transform.Translate(Vector3.forward * move.joystickValue.magnitude * Time.deltaTime);

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

            }
        }
    }
}