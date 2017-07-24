using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HeroSystem
{
    public class FactAttribute :MonoBehaviour
    {
        private static FactAttribute instance = null;

        public static FactAttribute Instance {
            get {
                return instance;
            }
        }
        // Use this for initialization
        void Start()
        {
            if (instance == null) {
                instance = null;
            }
        }

        void Update()
        {

        }
    }
}