using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLoginSystem {
    public class LoginUIController : MonoBehaviour {

        public GameObject registPanel;

        public GameObject loginPanel;

        public GameObject noticePanel;

        public GameObject MainPanel;

        public string ipAddress;

        public int port;
        // Use this for initialization
        void Start() {
        }

        // Update is called once per frame
        void Update() {

        }

        public void OnLoginButtonEntry() {
            MainPanel.SetActive(false);
            if (LoginNetWork.Instance.socket.Connected == false) {
                NoticePanelSetting.Instance.SettingNoticeMessage("网络断开连接中！",3);
                return;
            }
            loginPanel.SetActive(true);
            
        }

        public void OnRegisterButtonEntry() {
            MainPanel.SetActive(false);
            if(LoginNetWork.Instance.socket.Connected == false) {
                NoticePanelSetting.Instance.SettingNoticeMessage("网络断开连接中！", 3);
                return;
            }
            registPanel.SetActive(true);
            
        }

        public void OnCloseRegisterPanel() {
            registPanel.SetActive(false);
            MainPanel.SetActive(true);
        }

        public void OnCloseLoginPanel() {
            loginPanel.SetActive(false);
            MainPanel.SetActive(true);
        }


    }
}