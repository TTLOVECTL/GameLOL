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
}
