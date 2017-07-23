using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Excel;
using System.Data;
using UnityEngine;
using InscriptionSystem;
using EquipmentSystem;

public class ExcelReader {

    public static DataRowCollection ReadExcel(String path) {
        FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        DataSet result = excelReader.AsDataSet();
        return result.Tables[0].Rows;
    }

    public static List<Inscription> IninInscription(string path) {
        SortedDictionary<int, string> b = ExcelReader.InitAttrtibute("Attribute.xlsx");
        List<Inscription> _inscription = new List<Inscription>();
        path = Application.dataPath + "/" + path;
        DataRowCollection collect = ExcelReader.ReadExcel(path);
        for (int i = 1; i < collect.Count; i++)
        {
            if (collect[i][1].ToString() == "") continue;
            Inscription inscription = new Inscription();
            inscription.inscriptionID = int.Parse(collect[i][0].ToString());
            inscription.inscriptionName = collect[i][1].ToString();
            inscription.inscriptionLevel = int.Parse(collect[i][2].ToString());
            inscription.inscriptionColor = (InscriptionColor)int.Parse(collect[i][3].ToString());
            //inscription.inscriptionIcon = int.Parse(collect[i][4].ToString());
            for (int j = 5; collect[i][j].ToString() != ""; j = j + 2)
            {
                //Debug.Log(collect[i][j].ToString());
                InscriptionAttribute a = new InscriptionAttribute();
                a.attributeId = int.Parse(collect[i][j].ToString());
                a.attributeName = b[a.attributeId];
                a.attribueValue = float.Parse(collect[i][j + 1].ToString());
                if (a.attribueValue < 1)
                {
                    a.valueType = AttributeValue.PERCENTAGE;
                }
                else
                {
                    a.valueType = AttributeValue.NUMBER;
                }
                inscription.AddAttribute(a);

            }
            _inscription.Add(inscription);
        }
        return _inscription;
    }

    public static SortedDictionary<int, string> InitAttrtibute(string path) {
        SortedDictionary<int, string> a = new SortedDictionary<int, string>();
        path = Application.dataPath + "/" + path;
        DataRowCollection collect = ExcelReader.ReadExcel(path);
        for (int i = 1; i < collect.Count; i++)
        {
            if (collect[i][1].ToString() == "") continue;
            a.Add(int.Parse(collect[i][0].ToString()),collect[i][1].ToString());
        }
        return a;
    }

    public static List<BaseEquipment> InitEquiment(string path) {
        SortedDictionary<int, BaseEquipment> beList = new SortedDictionary<int, BaseEquipment>();
        SortedDictionary<int, EquipmentSkill> skillList = ExcelReader.InitEquipmentSkill("EquipmentSkill.xlsx");
        SortedDictionary<int, string> m = ExcelReader.InitAttrtibute("Attribute.xlsx");
        path = Application.dataPath + "/" + path;
        DataRowCollection collect = ExcelReader.ReadExcel(path);
        for (int i = 1; i < collect.Count; i++)
        {
            if (collect[i][1].ToString() == "") continue;
            BaseEquipment be;
            if (collect[i][6].ToString() == "0")
            {
                be = new EquipmentLeaf();
            }
            else {
                be = new EquipmentComponent();
            }
            be.equipmentId = int.Parse(collect[i][0].ToString());
            be.equipmentName = collect[i][1].ToString();
            //be.equipmentIcor = collect[i][1].ToString();
            be.equipmentPrice = int.Parse(collect[i][3].ToString());
            be.seaechType = (SearchType)int.Parse(collect[i][4].ToString());
            string[] a = collect[i][5].ToString().Split('/');
            for (int j = 0; j < a.Length; j++) {
                int num = int.Parse(a[j]);
                if (num != 0) {
                    be.AddChildEquipment(beList[num]);
                }
            }
            be.equipmentType = (EqunipmentType)int.Parse(collect[i][6].ToString());
            List<EquipmentSkill> eqlist = new List<EquipmentSkill>();

            string[] b = collect[i][7].ToString().Split('/');     
            for (int j = 0; j < b.Length; j++)
            {
                int num = int.Parse(b[j]);
                if (num != 0)
                {
                    if (skillList.ContainsKey(num))
                    {
                        eqlist.Add(skillList[num]);
                    }
                }
            }
            string[] c = collect[i][8].ToString().Split('/');
            for (int j = 0; j < c.Length; j++)
            {
                int num = int.Parse(c[j]);
                if (num != 0)
                {
                    if (skillList.ContainsKey(num))
                    {
                        eqlist.Add(skillList[num]);
                    }
                }
            }
            be.equipmentSkill = eqlist;

            List<int> numList = new List<int>();
            string[] k = collect[i][9].ToString().Split('/');
            if (!k[0].Equals("0"))
            {
                for (int j = 0; j < k.Length; j++)
                {
                    numList.Add(int.Parse(k[j]));
                }
            }
            be.parientEquipentList = numList;

            List<EquipmentAttribute> aList = new List<EquipmentAttribute>();
            for (int j = 10; collect[i][j].ToString() != ""; j = j + 2)
            {
                EquipmentAttribute eqa = new EquipmentAttribute();
                eqa._attributeId = int.Parse(collect[i][j].ToString());
                eqa._attributeName = m[eqa._attributeId];
                eqa._attributeValue = float.Parse(collect[i][j + 1].ToString());
                if (eqa._attributeValue < 1)
                {
                    eqa._attributeType = AttributeValue.PERCENTAGE;
                }
                else
                {
                    eqa._attributeType = AttributeValue.NUMBER;
                }
                aList.Add(eqa);
            }
            be.equipmentAttribute = aList;
            beList.Add(be.equipmentId,be);
        }

       

        List<BaseEquipment> tole = new List<BaseEquipment>();
        foreach (KeyValuePair<int, BaseEquipment> item in beList) {
            tole.Add(item.Value);
        }
        return tole;
    }

    public static SortedDictionary<int, EquipmentSkill> InitEquipmentSkill(string path) {
        SortedDictionary<int, EquipmentSkill> a = new SortedDictionary<int, EquipmentSkill>();
        path = Application.dataPath + "/" + path;
        DataRowCollection collect = ExcelReader.ReadExcel(path);
        for (int i = 1; i < collect.Count; i++)
        {
            if (collect[i][1].ToString() == "") continue;
            EquipmentSkill eq = new EquipmentSkill();
            eq.skillID = int.Parse(collect[i][0].ToString());
            eq.skillType = (SkillType)int.Parse(collect[i][1].ToString());
            eq.skillName = collect[i][2].ToString();
            //Debug.Log(eq.skillName);
            eq.skillDescription= collect[i][3].ToString();
            a.Add(eq.skillID, eq);
        }
        return a;
    }
}
