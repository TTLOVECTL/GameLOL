﻿using System;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using DataSystem;
using InscriptionSystem;
namespace GameLoginSystem
{
    public class LoadGameData : MonoBehaviour
    {

        public static string centerServerIP;

        public static int centerServerPort;

        public static int loginPlayerId;
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

            WWW www = new WWW("http://60.205.213.83:8080/Gamelol/"+LoadGameData.loginPlayerId.ToString()+".xml");
            try
            {
                while (!www.isDone)
                {
                    yield return www;
                    string text = System.Text.RegularExpressions.Regex.Replace(www.text, "^[^<]", "");
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(text);
                    XmlNodeList baseMessageNodeList = xmlDoc.SelectSingleNode("PlayerMessage/BaseMessage").ChildNodes;
                    foreach (XmlElement xe in baseMessageNodeList)
                    {
                        if (xe.Name == "playerId")
                            PlayerBaseMessage.PlayerId = int.Parse(xe.InnerText);
                        else if (xe.Name == "playerName")
                            PlayerBaseMessage.PlayerName = xe.InnerText;
                        else if (xe.Name == "playerLevel")
                            PlayerBaseMessage.PlayerLevel = int.Parse(xe.InnerText);
                        else if (xe.Name == "playerExperence")
                            PlayerBaseMessage.CurrentExperence = int.Parse(xe.InnerText);
                        else if (xe.Name == "playerHeadImage")
                            PlayerBaseMessage.HeadImage = int.Parse(xe.InnerText);
                        else if (xe.Name == "playerGoldNumber")
                            PlayerBaseMessage.GoldNumbere = int.Parse(xe.InnerText);
                        else if (xe.Name == "playerDiamondsNumber")
                            PlayerBaseMessage.DiamondsNumber = int.Parse(xe.InnerText);
                        else if (xe.Name == "playerVolumeNumber")
                            PlayerBaseMessage.VolumeNumber = int.Parse(xe.InnerText);
                        else if (xe.Name == "playerInscriptionNumber")
                            PlayerBaseMessage.InscriptionNumber = int.Parse(xe.InnerText);
                    }

                    XmlNodeList inscriptionNodeList = xmlDoc.SelectSingleNode("PlayerMessage/InscriptionMessage").ChildNodes;
                    foreach (XmlElement xe in inscriptionNodeList)
                    {
                        XmlNodeList xn = xe.ChildNodes;
                        InscriptionMessage inscriptionMessage = new InscriptionMessage();
                        foreach (XmlNode node in xn)
                        {
                            if (node.Name == "inscriptionId")
                                inscriptionMessage.inscriptionId = int.Parse(node.InnerText);
                            else if (node.Name == "inscriptionNumber")
                                inscriptionMessage.inscriptionNumber = int.Parse(node.InnerText);
                            else if (node.Name == "inscriptionUseNumber")
                                inscriptionMessage.inscriptionUseNumber = int.Parse(node.InnerText);
                        }
                        PlayerInscriptionMessage.InscriptionList.Add(inscriptionMessage.inscriptionId, inscriptionMessage);
                    }
                    XmlNodeList inscriptionPageNodeList = xmlDoc.SelectSingleNode("PlayerMessage/InscriptionPageMessage").ChildNodes;
                    foreach (XmlElement xe in inscriptionPageNodeList)
                    {
                        XmlNodeList xn = xe.ChildNodes;
                        InscriptionPageMode inscriptionPageMode = new InscriptionPageMode();
                        inscriptionPageMode._inscriptionModelList = new List<InscriptionModel>();
                        //InscriptionModel inscriptionModel = new InscriptionModel();
                        foreach (XmlNode node in xn)
                        {
                            if (node.Name == "InscriptionPageId")
                                inscriptionPageMode._inscriptionPageId = int.Parse(node.InnerText);
                            else if (node.Name == "InscriptionPageName")
                                inscriptionPageMode._inscriptionPageName = node.InnerText;
                            else if (node.Name == "BlueInscription")
                            {
                                if (int.Parse(node.InnerText) != 0)
                                {
                                    InscriptionModel inscriptionModel = new InscriptionModel();
                                    int soitId = int.Parse(((XmlElement)node).GetAttribute("SoitId"));
                                    inscriptionModel._inscriptionColor = InscriptionColor.BLUE;
                                    inscriptionModel._inscriptionID = int.Parse(node.InnerText);
                                    inscriptionModel._inscriptionPosId = soitId;
                                    inscriptionPageMode._inscriptionModelList.Add(inscriptionModel);
                                }
                            }
                            else if (node.Name == "RedInscription")
                            {
                                if (int.Parse(node.InnerText) != 0)
                                {
                                    InscriptionModel inscriptionModel = new InscriptionModel();
                                    int soitId = int.Parse(((XmlElement)node).GetAttribute("SoitId"));
                                    inscriptionModel._inscriptionColor = InscriptionColor.RED;
                                    inscriptionModel._inscriptionID = int.Parse(node.InnerText);
                                    inscriptionModel._inscriptionPosId = soitId;
                                    inscriptionPageMode._inscriptionModelList.Add(inscriptionModel);
                                }
                            }
                            else if (node.Name == "GreenInscription")
                            {
                                if (int.Parse(node.InnerText) != 0)
                                {
                                    InscriptionModel inscriptionModel = new InscriptionModel();
                                    int soitId = int.Parse(((XmlElement)node).GetAttribute("SoitId"));
                                    inscriptionModel._inscriptionColor = InscriptionColor.GREEN;
                                    inscriptionModel._inscriptionID = int.Parse(node.InnerText);
                                    inscriptionModel._inscriptionPosId = soitId;
                                    inscriptionPageMode._inscriptionModelList.Add(inscriptionModel);
                                }
                            }
                        }
                        PlayerInscriptionPageMessage.InscriptionPageList.Add(inscriptionPageMode._inscriptionPageId, inscriptionPageMode);
                    }
                    LoginNetWork.Instance.socket.Close();
                    NetConnection.NetWorkScript a= NetConnection.NetWorkScript.Instance;
                    UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
                }
            }
            finally
            {
                www.Dispose();
            }

        }
    }
}