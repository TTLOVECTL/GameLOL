using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HeroSystem.BaseHeroSystem
{
    public class AkaliController : MonoBehaviour, BaseHeroController
    {

        private int count=0;
        private Animator animator;

        private bool playFlag = true;

        private HeroState currentState = HeroState.IDLE;

        void Start()
        {
            animator = GetComponent<Animator>();
            GetComponent<HeroTouchController>().baseHeroController = this;

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

            }

            if (Input.GetKeyDown(KeyCode.Q))
            {

            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                OnTwoSkill();
            }
        }


        public void OnAnimationEnd()
        {
            playFlag = true;
            animator.SetInteger("state", (int)currentState);
        }

        public void OnOneSkill()
        {
            playFlag = false;
            animator.SetInteger("state", (int)HeroState.SKILLONE);
        }

        public void OnTwoSkill()
        {
            playFlag = false;
            animator.SetInteger("state", (int)HeroState.SKILLTWO);
        }

        public void OnThreeSkill()
        {
            playFlag = false;
            animator.SetInteger("state", (int)HeroState.SKILLETHREE);
        }

        public void OnAttack()
        {
            animator.SetInteger("state", (int)HeroState.ATTACK);
            if (count == 0)
            {
                animator.SetInteger("attacktype", count);
                count = 1;
            }
            else if(count == 1){
                animator.SetInteger("attacktype", count);
                count = 0;
            }
            
        }

        public void OnDie()
        {
            throw new NotImplementedException();
        }

        public void OnRun() {
            currentState = HeroState.RUN;
            if (playFlag)
            {
                animator.SetInteger("state", (int)HeroState.RUN);
            }
        }

        public void OnIdle() {
            currentState = HeroState.IDLE;
            if (playFlag)
            {
                animator.SetInteger("state", (int)HeroState.IDLE);
            }
        }
    }
}