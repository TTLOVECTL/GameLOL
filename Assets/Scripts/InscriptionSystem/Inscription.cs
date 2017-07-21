using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace InscriptionSystem
{
    [System.Serializable]
    public class Inscription
    {

        public int _inscriptionID;

        public int _inscriptionLevel;

        public string _inscriptionName;

        private Sprite _inscriptionIcon;

        private InscriptionColor _inscriptionColor;

        public  List<InscriptionAttribute> _inscriptionAttribute;

        public int inscriptionID
        {
            get
            {
                return _inscriptionID;
            }
            set
            {
                this._inscriptionID = value;
            }
        }

        public int inscriptionLevel
        {
            get
            {
                return _inscriptionLevel;
            }
            set
            {
                this._inscriptionLevel = value;
            }
        }

        public string inscriptionName
        {
            get
            {
                return _inscriptionName;
            }
            set
            {
                this._inscriptionName = value;
            }
        }

        public Sprite inscriptionIcon
        {
            get
            {
                return _inscriptionIcon;
            }
            set
            {
                this._inscriptionIcon = value;
            }
        }

        public InscriptionColor inscriptionColor


        {
            get
            {
                return _inscriptionColor;
            }
            set
            {
                this._inscriptionColor = value;
            }
        }

        public List<InscriptionAttribute> inscriptionAttribute
        {
            get
            {
                if (_inscriptionAttribute == null)
                {
                    _inscriptionAttribute = new List<InscriptionAttribute>();
                }
                return _inscriptionAttribute;
            }
        }

        public void AddAttribute(InscriptionAttribute attribute)
        {
            if (_inscriptionAttribute == null)
            {
                _inscriptionAttribute = new List<InscriptionAttribute>();
            }
            _inscriptionAttribute.Add(attribute);
        }
    }

}