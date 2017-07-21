using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InscriptionSystem;
using UnityEditor;

public class Test2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        readAsset();
        Init();
        InitFactory();
	}

    private void readAsset()
    {
        BookElementHolder ceh = AssetDatabase.LoadAssetAtPath<BookElementHolder>("Assets/QQ.asset");
        if (ceh == null)
        {
            Debug.Log("dasdsadsa");
            return;
        }
        Debug.Log(ceh.inscription.Count);
        foreach (Inscription gd in ceh.inscription)
        { 
             Debug.Log(gd.inscriptionName);
            foreach(InscriptionAttribute a in gd.inscriptionAttribute) {
                //Debug.Log("id:"+a.attributeId);
                //Debug.Log("value:"+a.attribueValue);
            }
        }
    }

    private void Init()
    {
        InscriptionPageMode ip = new InscriptionPageMode();
        ip._inscriptionPageId = 1;
        ip._inscriptionPageName = "法穿";
        ip._inscriptionModelList = new List<InscriptionModel>();
        for (int i = 0; i < 10; i++) {
            InscriptionModel im = new InscriptionModel();
            im._inscriptionColor = InscriptionColor.GREEN;
            im._inscriptionID = 2;
            im._inscriptionPosId = i;
            ip._inscriptionModelList.Add(im);
        }

        for (int i = 0; i < 10; i++)
        {
            InscriptionModel im = new InscriptionModel();
            im._inscriptionColor = InscriptionColor.RED;
            im._inscriptionID = 1;
            im._inscriptionPosId = i;
            ip._inscriptionModelList.Add(im);
        }
        for (int i = 0; i < 10; i++)
        {
            InscriptionModel im = new InscriptionModel();
            im._inscriptionColor = InscriptionColor.BLUE;
            im._inscriptionID = 8;
            im._inscriptionPosId = i;
            ip._inscriptionModelList.Add(im);
        }
        InscriptionConst._instcriptionPageModel.Add(ip);
    }

    private void InitFactory() {
        InscriptionPage a = InscriptionPageFactory.Instance.GetInscriptionPageById(1);
        if (a == null) {
            Debug.Log(2313);
        }
        a.CalculatedAttribute();
        Debug.Log(a.inscriptionAttribute.Count);
        foreach (KeyValuePair<int, InscriptionAttribute> item in a.inscriptionAttribute) {
            Debug.Log(item.Value.attributeName+"："+item.Value.attribueValue.ToString());
        }
    }
}
