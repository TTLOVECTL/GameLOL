using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        private   SortedDictionary<int, InscriptionPage> _inscriptionPageList = new SortedDictionary<int, InscriptionPage>();

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
            foreach (InscriptionPageMode insPM in InscriptionConst._instcriptionPageModel) {
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
                _inscriptionPageList.Add(insPM._inscriptionPageId,iPage);
            }
        }
    }
}