using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataSystem;
namespace InscriptionSystem {

    /// <summary>
    /// 生产符文页的工厂
    /// </summary>
    public class InscriptionPageFactory {

        /// <summary>
        /// 符文页工厂唯一的实例
        /// </summary>
        private static InscriptionPageFactory instance = null;

        /// <summary>
        /// 存储一系列的符文页
        /// </summary>
        private SortedDictionary<int, InscriptionPage> _inscriptionPageList = new SortedDictionary<int, InscriptionPage>();

        /// <summary>
        /// 私有构造函数
        /// </summary>
        private InscriptionPageFactory() {
            InitInscriptionPage();
        }

        /// <summary>
        /// 获取唯一的实例对象
        /// </summary>
        public static InscriptionPageFactory Instance {
            get {
                if (instance == null) {
                    instance = new InscriptionPageFactory();
                }
                return instance;
            }
        }

        public void AddNewInscripttion(int inscriptionPageId, InscriptionPage inscriptionPage)
        {
            if (_inscriptionPageList.ContainsKey(inscriptionPageId)) 
                return;
            _inscriptionPageList.Add(inscriptionPageId, inscriptionPage);
        }
        /// <summary>
        /// 通过Id获取指定的符文页
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  InscriptionPage GetInscriptionPageById(int id) {
            if (_inscriptionPageList.ContainsKey(id))
            {
                return _inscriptionPageList[id];
            }
            else {
                return null;
            }
        }

        /// <summary>
        /// 初始化符文工厂
        /// </summary>
        private void InitInscriptionPage() {
            foreach(KeyValuePair<int, InscriptionPageMode> item in PlayerInscriptionPageMessage.InscriptionPageList ) {
                InscriptionPageMode insPM = item.Value;
                InscriptionPage iPage = new InscriptionPage();
                iPage.pageId = insPM._inscriptionPageId;
                iPage.pageName = insPM._inscriptionPageName;
                foreach (InscriptionModel inscrModle in insPM._inscriptionModelList) {
                    Inscription insc = InscriptionFactory.Instance.GetInscriptionById(inscrModle._inscriptionID);
                    switch (inscrModle._inscriptionColor) {
                        case InscriptionColor.GREEN:             
                            iPage.SetGreenInscription(insc,inscrModle._inscriptionPosId);
                            break;
                        case InscriptionColor.RED:
                            iPage.SetRedInscription(insc, inscrModle._inscriptionPosId);
                            break;
                        case InscriptionColor.BLUE:
                            iPage.SetBlueInsciption(insc, inscrModle._inscriptionPosId);
                            break;
                    }
                }
                if (!_inscriptionPageList.ContainsKey(insPM._inscriptionPageId))
                {
                    _inscriptionPageList.Add(insPM._inscriptionPageId, iPage);
                }
            }
        }

        /// <summary>
        /// 获取去处该符文页使用的指定颜色的符文
        /// </summary>
        /// <param name="color"></param>
        /// <param name="inscriptionPageId"></param>
        /// <returns></returns>
        public List<RestInscription> GetRestInscriptionList(InscriptionColor color,int inscriptionPageId)
        {
            List<RestInscription> inscriptionList = new List<RestInscription>();
            foreach (KeyValuePair<int, InscriptionMessage> item in PlayerInscriptionMessage.InscriptionList) {
                //Debug.Log(InscriptionFactory.Instance.GetInscriptionById(item.Value.inscriptionId).inscriptionName+":"+item.Value.inscriptionNumber);
                if (InscriptionFactory.Instance.GetInscriptionById(item.Value.inscriptionId).inscriptionColor == color) {
                    int max = 0;
                    switch (color) {
                        case InscriptionColor.BLUE:
                            foreach(KeyValuePair<int,Inscription> value in GetInscriptionPageById(inscriptionPageId).blueInscription)
                            {
                                if (value.Value.inscriptionID == item.Value.inscriptionId) {
                                    max++;
                                }
                            }
                            break;
                        case InscriptionColor.GREEN:
                            foreach (KeyValuePair<int, Inscription> value in GetInscriptionPageById(inscriptionPageId).greenInscription)
                            {
                                if (value.Value.inscriptionID == item.Value.inscriptionId)
                                {
                                    max++;
                                }
                            }
                            break;
                        case InscriptionColor.RED:
                            foreach (KeyValuePair<int, Inscription> value in GetInscriptionPageById(inscriptionPageId).redInscription)
                            {
                                if (value.Value.inscriptionID == item.Value.inscriptionId)
                                {
                                    max++;
                                }
                            }
                            break;
                    }
                    if (item.Value.inscriptionNumber - max > 0) {
                        RestInscription restInscription = new RestInscription();
                        restInscription.inscriptionId = item.Value.inscriptionId;
                        restInscription.inscriptionNumber = item.Value.inscriptionNumber - max;
                        inscriptionList.Add(restInscription);
                    }
                }
            }

            return inscriptionList;

        }

        /// <summary>
        /// 获取指定符文使用的数量
        /// </summary>
        /// <param name="inscriptionId"></param>
        /// <returns></returns>
        public int GetInscriptionMaxNumber(int inscriptionId) {
            int max = 0;
            int temp = 0;
            foreach (KeyValuePair<int, InscriptionPage> item in _inscriptionPageList) {
                switch (InscriptionFactory.Instance.GetInscriptionById(inscriptionId).inscriptionColor)
                {
                    case InscriptionColor.RED:
                        temp = 0;
                        foreach (KeyValuePair<int,Inscription> value in item.Value.redInscription) {
                            if (value.Value.inscriptionID == inscriptionId) {
                                temp++;
                            }
                        }
                        if (temp > max)
                            max = temp;
                        break;
                    case InscriptionColor.BLUE:
                       temp = 0;
                        foreach (KeyValuePair<int, Inscription> value in item.Value.blueInscription)
                        {
                            if (value.Value.inscriptionID == inscriptionId)
                            {
                                temp++;
                            }
                        }
                        if (temp > max)
                            max = temp;
                        break;
                    case InscriptionColor.GREEN:
                        temp = 0;
                        foreach (KeyValuePair<int, Inscription> value in item.Value.greenInscription)
                        {
                            if (value.Value.inscriptionID == inscriptionId)
                            {
                                temp++;
                            }
                        }
                        if (temp > max)
                            max = temp;
                        break;
                }
               
            }
            return max;
        }
    }

    /// <summary>
    /// 剩下的符文
    /// </summary>
    public class RestInscription {
        public int inscriptionId;
        public int inscriptionNumber;
    }
}