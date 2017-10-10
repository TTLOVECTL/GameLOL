using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
namespace GameLoginSystem
{
    public class RegisterPanelSetting : MonoBehaviour
    {
        /// <summary>
        /// 账户输入区
        /// </summary>
        public InputField accountFiled;

        /// <summary>
        /// 密码输入区
        /// </summary>
        public InputField firstPasswordField;

        /// <summary>
        /// 确认密码输入区
        /// </summary>
        public InputField secondPasswordField;

        /// <summary>
        /// 加载面板
        /// </summary>
        public GameObject loadImagePanel;
        /// <summary>
        /// 注册按钮相应事件
        /// </summary>
        public void OnRegisterAccount() {
            string account = accountFiled.text;
            string password1 = firstPasswordField.text;
            string password2 = secondPasswordField.text;
            gameObject.SetActive(false);
            if (account == "")
            {
                NoticePanelSetting.Instance.SettingNoticeMessage("请输入注册账号！",1);
            }
            else if (password1 == "" || password2 == "")
            {
                NoticePanelSetting.Instance.SettingNoticeMessage("请输入注册密码！",1);
            }
            else if (!password1.Equals(password2))
            {
                NoticePanelSetting.Instance.SettingNoticeMessage("两次输入密码不一致！",1);
            }
            else {
                 LoginMessage loginMessage = new LoginMessage();
                 loginMessage.account = int.Parse(accountFiled.text);
                 loginMessage.password = firstPasswordField.text;
                 LoginNetWork.Instance.write(2, 1, 0, JsonMapper.ToJson(loginMessage));
                 loadImagePanel.SetActive(true);
            }
        }
    }
}