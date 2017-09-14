using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameLoginSystem {
    public class NoticePanelSetting : MonoBehaviour {

        private static NoticePanelSetting instance = null;

        public GameObject noticePanel;

        public GameObject registerPanel;

        public GameObject loginPanel;

        public Text noticeMessage;

        public GameObject loadImagePanel;

        public GameObject mainPanel;

        private int currentPanel;

        private void Awake()
        {
            if (instance == null) {
                instance = this;
            }
        }

        public static NoticePanelSetting Instance {
            get {
                return instance;
            }
        }

        public void SettingNoticeMessage(string message,int panelType) {
            noticePanel.SetActive(true);
            noticeMessage.text = message;
            currentPanel = panelType;
        }

        public void CloseNoticePanel() {
            noticePanel.SetActive(false);
            switch (currentPanel) {
                case 1:
                    registerPanel.SetActive(true);
                    break;
                case 2:
                    loginPanel.SetActive(true);
                    break;
                case 3:
                    mainPanel.SetActive(true);
                    break;

            }
        }

    }
}