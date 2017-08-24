using System;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using InscriptionSystem;
using UnityEngine.UI;
public class XmlDataRead : MonoBehaviour
{
    public static List<Inscription> inscriptionList = null;
    public static SortedDictionary<int, string> attributeList = null;

    private void Start()
    {
        StartCoroutine(LoadInscription(GetPlatformPath("", "Inscription.xml")));
    }

    IEnumerator LoadInscription(string path)
    {

        if (attributeList == null)
        {

            SortedDictionary<int, string> listAttribute = new SortedDictionary<int, string>();
            WWW wwwAttribute = new WWW(GetPlatformPath("", "Attribute.xml"));
            try
            {
                while (!wwwAttribute.isDone)
                {
                    yield return wwwAttribute;
                    XmlDocument xmlDoc = new XmlDocument();
                    string text = System.Text.RegularExpressions.Regex.Replace(wwwAttribute.text, "^[^<]", "");
                    xmlDoc.LoadXml(text);

                    XmlNodeList nodeList = xmlDoc.SelectSingleNode("AttributeSystem").ChildNodes;
                    foreach (XmlElement xe in nodeList)
                    {
                        listAttribute.Add(int.Parse(xe.GetAttribute("id").ToString()), xe.InnerText);
                    }
                    if (listAttribute.Count >= 0)
                        attributeList = listAttribute;
                }
            }
            finally
            {
                wwwAttribute.Dispose();
            }
        }

        List<Inscription> list = new List<Inscription>();

        WWW bundle = new WWW(GetPlatformPath("", "inscription.assetbundle"));
        yield return bundle;

        WWW www = new WWW(path);

        while (!www.isDone)
        {
            yield return www;

            XmlDocument xmlDoc = new XmlDocument();
            String text = System.Text.RegularExpressions.Regex.Replace(www.text, "^[^<]", "");
            xmlDoc.LoadXml(text);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("InscriptionSystem").ChildNodes;

            foreach (XmlElement xe in nodeList)
            {
                Inscription inscription = new Inscription();
                XmlNodeList xnl0 = xe.ChildNodes;
                foreach (XmlNode node in xnl0)
                {
                    if (node.InnerText == "")
                    {
                        continue;
                    }
                    if (node.Name == "id")
                    {
                        inscription._inscriptionID = int.Parse(node.InnerText);
                    }
                    else if (node.Name == "name")
                    {
                        inscription._inscriptionName = node.InnerText.ToString();
                    }
                    else if (node.Name == "level")
                    {
                        inscription._inscriptionLevel = int.Parse(node.InnerText.ToString());
                    }
                    else if (node.Name == "color")
                    {
                        inscription._inscriptionColor = (InscriptionColor)int.Parse(node.InnerText.ToString());
                    }
                    else if (node.Name == "icon")
                    {
                        inscription._inscriptionIcon = Sprite.Create(bundle.assetBundle.LoadAsset(inscription.inscriptionName) as Texture2D, new Rect(0, 0, 128, 128), Vector2.zero);
                    }
                    else if (node.Name == "attibuteList")
                    {
                        List<InscriptionAttribute> ab = new List<InscriptionAttribute>();
                        XmlNodeList xnl1 = node.ChildNodes;
                        foreach (XmlElement node1 in xnl1)
                        {
                            InscriptionAttribute a = new InscriptionAttribute();
                            a.attributeId = int.Parse(node1.GetAttribute("id"));

                            a.attributeName = attributeList[a.attributeId];
                            float b = float.Parse(node1.InnerText.ToString());

                            if (b < 0.1)
                            {
                                a.valueType = AttributeValue.PERCENTAGE;
                            }
                            else
                            {
                                a.valueType = AttributeValue.NUMBER;
                            }
                            a._attributeValue = b;
                            ab.Add(a);
                        }
                        inscription._inscriptionAttribute = ab;
                    }
                }

                list.Add(inscription);

            }
            inscriptionList = list;
        }
    }

    private static string GetPlatformPath(string flodername, string filename)
    {
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
