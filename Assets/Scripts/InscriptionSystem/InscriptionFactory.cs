using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;


namespace InscriptionSystem
{
    /// <summary>
    /// 符文生产工厂
    /// </summary>
    public class InscriptionFactory
    {
        /// <summary>
        /// 符文工厂的唯一实例
        /// </summary>
        private static InscriptionFactory _instance = null;

        public List<Inscription> _inscription = null;

        private InscriptionFactory()
        {
            _inscription = new List<Inscription>();
            InitInscription();
        }

        public static InscriptionFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InscriptionFactory();
                }
                return _instance;
            }
        }

        public void InitInscription()
        {
            string path = Application.dataPath + "/Inscription.xlsx";
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

                    a.attributeName = collect[i][j].ToString();
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
        }

        public List<Inscription> GetInscriptionByAttributeName(string attributeName)
        {
            List<Inscription> conditionInscription = new List<Inscription>();
            foreach (Inscription inscription in _inscription)
            {
                List<InscriptionAttribute> attribute = inscription.inscriptionAttribute;
                foreach (InscriptionAttribute a in attribute)
                {
                    if (a.attributeName.Equals(attributeName))
                    {
                        conditionInscription.Add(inscription);
                        break;
                    }
                }
            }
            return conditionInscription;

        }

        public List<Inscription> GetInscriptionByLevel(int level)
        {
            List<Inscription> conditionInscription = new List<Inscription>();
            foreach (Inscription inscription in _inscription)
            {
                if (inscription.inscriptionLevel == level)
                {
                    conditionInscription.Add(inscription);
                }
            }
            return conditionInscription;
        }

    }
}