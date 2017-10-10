using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

namespace GameLoginSystem
{
    public class LoginPanelSetting : MonoBehaviour
    {
        /// <summary>
        /// 登录面板账号输入区
        /// </summary>
        public InputField accountField;

        /// <summary>
        /// 登录面板密码输入区
        /// </summary>
        public InputField passwordField;

        /// <summary>
        /// 加载面板
        /// </summary>
        public GameObject loadImagePanel;

        /// <summary>
        /// 登录按钮响应事件
        /// </summary>
        public void OnLoginAccount() {
            string account = accountField.text;
            string password = passwordField.text;
            gameObject.SetActive(false);
            if (account == "")
            {
                NoticePanelSetting.Instance.SettingNoticeMessage("登录账号输入不能为空！", 2);
            }
            else if (password == "")
            {
                NoticePanelSetting.Instance.SettingNoticeMessage("登录密码输入不能为空！", 2);
            }
            else {
                LoginMessage loginMessage = new LoginMessage();
                loginMessage.account = int.Parse(accountField.text);
                loginMessage.password = passwordField.text;
                LoginNetWork.Instance.write(2,2,0, JsonMapper.ToJson(loginMessage));
                loadImagePanel.SetActive(true);
            }
        }

    }
}