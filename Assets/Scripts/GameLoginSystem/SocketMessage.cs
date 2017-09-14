using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TNet;
using System.IO;
using System;
using LitJson;
namespace GameLoginSystem
{
    public class SocketMessage
    {
        public static bool flag = false;

        public static void Receive(BinaryReader reader) {
            int type = reader.ReadInt32();
            switch (type) {
                case 1:
                    switch (reader.ReadInt32()) {
                        case 1:
                            NoticePanelSetting.Instance.loadImagePanel.SetActive(false);
                            NoticePanelSetting.Instance.SettingNoticeMessage("账号注册成功！",3);
                            break;
                        case 2:
                            NoticePanelSetting.Instance.loadImagePanel.SetActive(false);
                            NoticePanelSetting.Instance.SettingNoticeMessage("注册的账号已经存在了！", 1);
                            break;
                    }
                    break;
                case 2:
                    switch (reader.ReadInt32()) {
                        case 1:
                            flag = true;
                            break;
                        case 2:
                            NoticePanelSetting.Instance.loadImagePanel.SetActive(false);
                            NoticePanelSetting.Instance.SettingNoticeMessage("登录账号不存在！", 2);
                            break;
                        case 3:
                            NoticePanelSetting.Instance.loadImagePanel.SetActive(false);
                            NoticePanelSetting.Instance.SettingNoticeMessage("登录账号密码错误！",2);
                            break;

                    }
                    break;
            }
        }


        public static void Send<T>(T message,int type) {
            string messageStr = JsonMapper.ToJson(message);
            if (TNManager.isConnected) {
                BinaryWriter write = TNManager.BeginSend(Packet.SelfServerPacket);
                write.Write(type);
                write.Write(messageStr);
                TNManager.EndSend();
            }
        }

    }
}