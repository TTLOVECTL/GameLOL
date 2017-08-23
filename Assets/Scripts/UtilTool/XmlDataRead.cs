using System;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using InscriptionSystem;


public class XmlDataRead:MonoBehaviour {


    public static List<Inscription> inscriptionList = null;
    public static SortedDictionary<int,string> attributeList = null;
    public void ReadInscription(string flodername, string filename)
    {
        StartCoroutine(LoadInscription(GetPlatformPath("", "Inscription")));
    }

    IEnumerator LoadInscription(string path) {

        if (attributeList == null) {
            SortedDictionary<int, string> listAttribute = new SortedDictionary<int, string>();
            WWW wwwAttribute = new WWW(GetPlatformPath("", "Attribute"));
            while (!wwwAttribute.isDone)
            {
                yield return wwwAttribute;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(wwwAttribute.text);
                XmlNodeList nodeList = xmlDoc.SelectSingleNode("attibute").ChildNodes;
                foreach (XmlElement xe in nodeList)
                {
                    listAttribute.Add(int.Parse(xe.GetAttribute("id").ToString()), xe.InnerText);
                }
                if (listAttribute.Count >= 0)
                    attributeList = listAttribute;
            }
        }
        List<Inscription> list = new List<Inscription>();

        WWW www = new WWW(path);
        while (!www.isDone)
        {
            yield return www;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(www.text);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("InscrptionSystem").ChildNodes;
            foreach (XmlElement xe in nodeList) {
                Inscription inscription = new Inscription();
                XmlNodeList xnl0 = xe.ChildNodes;
                foreach (XmlNode node in xnl0) {
                    if (node.Name == "id")
                    {
                        inscription._inscriptionID = int.Parse(node.InnerText);
                    }
                    else if (node.Name == "name")
                    {
                        inscription._inscriptionName = node.InnerText;
                    }
                    else if (node.Name == "level")
                    {
                        inscription._inscriptionLevel = int.Parse(node.InnerText);
                    }
                    else if (node.Name == "color")
                    {
                        inscription._inscriptionColor = (InscriptionColor)int.Parse(node.InnerText);
                    }
                    else if (node.Name == "icon")
                    {

                    }
                    else if (node.Name == "attributeList") {
                        List<Attribute> ab = new List<Attribute>();
                        XmlNodeList xnl1 = node.ChildNodes;

                    }
                }
            }
        }
    }

    private static string GetPlatformPath(string flodername, string filename) {
        string filePath =
#if UNITY_ANDROID && !UNITY_EDITOR
        "jar:file://" + Application.dataPath + "!/assets/" + flodername + "/";  
#elif UNITY_IPHONE && !UNITY_EDITOR
        Application.dataPath + "/Raw/";  
#elif UNITY_STANDALONE_WIN || UNITY_EDITOR
 "file://" + Application.dataPath + "/StreamingAssets" + "/" + flodername + "/";
#else
        string.Empty;  
#endif

        return filePath += filename;
    }

}
