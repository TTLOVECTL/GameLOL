using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using UnityEditor;

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

        private  List<Inscription> _inscription = null;

        /// <summary>
        /// 存储所有的符文实例
        /// </summary>
        public List<Inscription> inscription {
            get {
                if (_inscription == null)
                    _inscription = new List<Inscription>();
                return _inscription;
            }
        }

        /// <summary>
        /// 私有构造方法
        /// </summary>
        private InscriptionFactory()
        {
            _inscription = new List<Inscription>();
            InitInscription();
        }

        /// <summary>
        /// 外部获取实例的途径
        /// </summary>
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

        /// <summary>
        /// 初始化工厂类
        /// </summary>
        public void InitInscription()
        {
            InscriptionHolder ceh = AssetDatabase.LoadAssetAtPath<InscriptionHolder>("Assets/Assets/Inscription.asset");
            if (ceh == null)
            {
                return;
            }
            _inscription = ceh.inscription;
            
        }///此处是重点

        /// <summary>
        /// 根据名字获取指定的符文
        /// </summary>
        /// <param name="attributeName"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 根据符文等级获取指定的符文
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 根据符文ID获取指定的符文
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Inscription GetInscriptionById(int id) {
            Inscription ins = new Inscription();
            foreach (Inscription inscription in _inscription) {
                if (inscription.inscriptionID == id) {
                    ins = inscription;
                }
            }
            return ins;
        }

        /// <summary>
        /// 根据符文属性的Id获取指定的符文
        /// </summary>
        /// <param name="attributId"></param>
        /// <returns></returns>
        public List<Inscription> GetInscriptionByAttributeId(int attributId) {
            List<Inscription> conditionInscription = new List<Inscription>();
            foreach (Inscription inscription in _inscription)
            {
                List<InscriptionAttribute> attribute = inscription.inscriptionAttribute;
                foreach (InscriptionAttribute a in attribute)
                {
                    if (a.attributeId==attributId)
                    {
                        conditionInscription.Add(inscription);
                        break;
                    }
                }
            }
            return conditionInscription;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void ReleaseResource() {
            _inscription.Clear();
        }
    }
}