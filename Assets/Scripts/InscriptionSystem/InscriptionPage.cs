using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InscriptionSystem
{
    /// <summary>
    /// 符文页设计
    /// </summary>
    public class InscriptionPage 
    {

        private int _pageId;

        /// <summary>
        /// 符文页Id
        /// </summary>
        public int pageId {
            set { this._pageId = value; }
            get { return pageId; }
        }

        private string _pageName;

        /// <summary>
        /// 符文页名称
        /// </summary>
        public string pageName {
            get { return _pageName; }
            set { this._pageName = value; }
        }

        private SortedDictionary<int, Inscription> _greenInscription = null;

        /// <summary>
        ///绿色符文
        /// </summary>
        public SortedDictionary<int, Inscription> greenInscription {
            get {
                if (_greenInscription == null) {
                    _greenInscription = new SortedDictionary<int, Inscription>();
                }
                return _greenInscription;
            }
        }

        private SortedDictionary<int, Inscription> _redInsription =null;

        /// <summary>
        /// 红色符文
        /// </summary>
        public SortedDictionary<int, Inscription> redInscription {
            get
            {
                if (_redInsription == null) {
                    _redInsription = new SortedDictionary<int, Inscription>();
                }
                return _redInsription;
            }
        }

        private SortedDictionary<int, Inscription> _blueInscriotion =null;

        /// <summary>
        /// 蓝色符文
        /// </summary>
        public SortedDictionary<int,Inscription> blueInscription
        {
            get {
                if (_blueInscriotion == null) {
                    _blueInscriotion = new SortedDictionary<int, Inscription>();
                }
                return _blueInscriotion;
            }
        }

        private SortedDictionary<int, InscriptionAttribute> _inscriptionAttribue = null;

        /// <summary>
        /// 最终的符文属性列表
        /// </summary>
        public SortedDictionary<int, InscriptionAttribute> inscriptionAttribute {
            get {
                if (_inscriptionAttribue == null) {
                    _inscriptionAttribue = new SortedDictionary<int, InscriptionAttribute>();
                }
                return _inscriptionAttribue;
            }
        }

        /// <summary>
        ///在指定位置添加绿色符文
        /// </summary>
        /// <param name="greenIns"></param>
        /// <param name="posID"></param>
        public void SetGreenInscription(Inscription greenIns,int posID) {
            if (_greenInscription == null) {
                _greenInscription = new SortedDictionary<int, Inscription>();
            }
            if ((posID > 10 && posID <= 0)||_greenInscription.ContainsKey(posID)) {
                return;
            }
            AddAttribueUpdate(greenIns);
            _greenInscription.Add(posID,greenIns);
        }

        /// <summary>
        /// 在指定位置添加红色符文
        /// </summary>
        /// <param name="redIns"></param>
        /// <param name="posID"></param>
        public void SetRedInscription(Inscription redIns,int posID) {
            if (_redInsription == null) {
                _redInsription = new SortedDictionary<int, Inscription>();
            }
            if ((posID > 10 && posID <= 0) || _redInsription.ContainsKey(posID))
            {
                return;
            }
            AddAttribueUpdate(redIns);
            _redInsription.Add(posID,redIns);
        }

        /// <summary>
        /// 在指定位置添加蓝色符文
        /// </summary>
        /// <param name="blueIns"></param>
        /// <param name="posID"></param>
        public void SetBlueInsciption(Inscription blueIns,int posID) {
            if (_blueInscriotion == null) {
                _blueInscriotion = new SortedDictionary<int, Inscription>();
            }
            if ((posID > 10 && posID <= 0) || _blueInscriotion.ContainsKey(posID)) {
                return;
            }
            AddAttribueUpdate(blueIns);
            _blueInscriotion.Add(posID,blueIns);
        }

        /// <summary>
        /// 移除指定位置的
        /// </summary>
        /// <param name="posID"></param>
        public void RemoveGreenInscription(int posID) {
            if (_greenInscription.ContainsKey(posID)) {
                RemoveAttributeUpdata(_greenInscription[posID]);
                _greenInscription.Remove(posID);
                
            }
        }

        /// <summary>
        /// 移除指定位置的红色符文
        /// </summary>
        /// <param name="posID"></param>
        public void RemoveRedInscription(int posID) {
            if (_redInsription.ContainsKey(posID)) {
                RemoveAttributeUpdata(_redInsription[posID]);
                _redInsription.Remove(posID);
            }
        }

        /// <summary>
        /// 移除指定位置的蓝色符文
        /// </summary>
        /// <param name="posID"></param>
        public void RemoveBlueInscription(int posID) {
            if (_blueInscriotion.ContainsKey(posID)) {
                RemoveAttributeUpdata(_blueInscriotion[posID]);
                _blueInscriotion.Remove(posID);
            }
        }

        /// <summary>
        /// 计算符文的综合属性
        /// </summary>
        public void CalculatedAttribute() {
            if (_inscriptionAttribue == null) {
                _inscriptionAttribue = new SortedDictionary<int, InscriptionAttribute>();
            }
            _inscriptionAttribue.Clear();
            foreach (KeyValuePair<int, Inscription> incriptionItem in _greenInscription) {
                foreach (InscriptionAttribute attributeItem in incriptionItem.Value.inscriptionAttribute) {
                    if (_inscriptionAttribue.ContainsKey(attributeItem.attributeId))
                    {
                        _inscriptionAttribue[attributeItem.attributeId].attribueValue += attributeItem.attribueValue;
                    }
                    else {
                        InscriptionAttribute a = ChangeAttribute(attributeItem);
                        _inscriptionAttribue.Add(attributeItem.attributeId,a);
                    }
                }
            }

            foreach (KeyValuePair<int, Inscription> incriptionItem in _redInsription)
            {
                foreach (InscriptionAttribute attributeItem in incriptionItem.Value.inscriptionAttribute)
                {
                    if (_inscriptionAttribue.ContainsKey(attributeItem.attributeId))
                    {
                        _inscriptionAttribue[attributeItem.attributeId].attribueValue += attributeItem.attribueValue;
                    }
                    else
                    {
                        InscriptionAttribute a = ChangeAttribute(attributeItem);
                        _inscriptionAttribue.Add(attributeItem.attributeId, a);
                    }
                }
            }

            foreach (KeyValuePair<int, Inscription> incriptionItem in blueInscription)
            {
                foreach (InscriptionAttribute attributeItem in incriptionItem.Value.inscriptionAttribute)
                {
                    if (_inscriptionAttribue.ContainsKey(attributeItem.attributeId))
                    {
                        _inscriptionAttribue[attributeItem.attributeId].attribueValue += attributeItem.attribueValue;
                    }
                    else
                    {
                        InscriptionAttribute a = ChangeAttribute(attributeItem);
                        _inscriptionAttribue.Add(attributeItem.attributeId, a);
                    }
                }
            }

        }

        /// <summary>
        /// 添加铭文时，更新属性
        /// </summary>
        /// <param name="inscription"></param>
        private void AddAttribueUpdate(Inscription inscr) {
            if (_inscriptionAttribue == null)
            {
                _inscriptionAttribue = new SortedDictionary<int, InscriptionAttribute>();
            }
            foreach (InscriptionAttribute attributeItem in inscr.inscriptionAttribute) {
                //Debug.Log("id:"+attributeItem.attributeId);
                //Debug.Log("value:"+attributeItem.attribueValue);
                if (_inscriptionAttribue.ContainsKey(attributeItem.attributeId))
                {
                    _inscriptionAttribue[attributeItem.attributeId].attribueValue += attributeItem.attribueValue;
                }
                else
                {
                    InscriptionAttribute a = ChangeAttribute(attributeItem);
                    _inscriptionAttribue.Add(attributeItem.attributeId, a);
                }
            }
        }

        /// <summary>
        /// 移除铭文时，更新属性
        /// </summary>
        /// <param name="inscr"></param>
        private void RemoveAttributeUpdata(Inscription inscr) {
            if (_inscriptionAttribue == null)
            {
                _inscriptionAttribue = new SortedDictionary<int, InscriptionAttribute>();
            }
            foreach (InscriptionAttribute attributeItem in inscr.inscriptionAttribute)
            {
                if (_inscriptionAttribue.ContainsKey(attributeItem.attributeId))
                {
                    _inscriptionAttribue[attributeItem.attributeId].attribueValue -= attributeItem.attribueValue;
                    if (_inscriptionAttribue[attributeItem.attributeId].attribueValue <= 0) {
                        _inscriptionAttribue.Remove(attributeItem.attributeId);
                    }
                }
                else
                {
                    Debug.Log("There has many error!");
                }
            }
        }

        private InscriptionAttribute ChangeAttribute(InscriptionAttribute a) {
            InscriptionAttribute b= new InscriptionAttribute();
            b.attributeId = a.attributeId;
            b.attributeName = a.attributeName;
            b.attribueValue = a.attribueValue;
            b.valueType = a.valueType;
            return b;
        }

        /// <summary>
        /// 计算符文页的符文总等级
        /// </summary>
        /// <returns></returns>
        public int CalculatedInscriptionLevel() {
            int level = 0;
            foreach (KeyValuePair<int, Inscription> reditem in redInscription) {
                level += reditem.Value.inscriptionLevel;
            }
            foreach (KeyValuePair<int, Inscription> greenitem in greenInscription)
            {
                level += greenitem.Value.inscriptionLevel;
            }
            foreach (KeyValuePair<int, Inscription> blueitem in blueInscription)
            {
                level += blueitem.Value.inscriptionLevel;
            }
            return level;
        }
    }
}