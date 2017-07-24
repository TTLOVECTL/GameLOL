using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InscriptionSystem
{
    public class InscriptionButton : MonoBehaviour
    {

        public int inscription = 0;

        public void OnSearchInscription()
        {
            if (inscription == 0) {
                return;
            }
        }
    }
}