using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameLoginSystem
{
    public class LoadGameData : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (SocketMessage.flag) {
                StartCoroutine(LoadData());
                SocketMessage.flag = false;
            }
        }

        IEnumerator LoadData() {
            yield return null;
            
        }
    }
}