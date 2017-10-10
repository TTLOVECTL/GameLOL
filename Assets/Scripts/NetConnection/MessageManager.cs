using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetConnection
{
    public class MessageManager : MonoBehaviour
    {
        private static MessageManager instance = null;

        IHandle user;
        IHandle login;
        // Use this for initialization
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else {
                Destroy(this.gameObject);
            }
            //user = GetComponent<UserHandler>();
            //login = GetComponent<LoginHandler>();
        }

        // Update is called once per frame
        void Update()
        {
            while (NetWorkScript.Instance.messageList.Count > 0)
            {
                SocketModel model = NetWorkScript.Instance.messageList[0];
                NetWorkScript.Instance.messageList.RemoveAt(0);
                StartCoroutine("MessageReceive", model);
            }
        }

        void MessageReceive(SocketModel model)
        {
            switch (model.type)
            {
                //case Protocol.TYPE_USER:
                //    user.MessageReceive(model);
                //    break;
                //case Protocol.TYPE_LOGIN:
                //    login.MessageReceive(model);
                //    break;
            }
        }
    }
}