using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InscriptionSystem.UI.Old {
    /// <summary>
    /// 符文传输模型
    /// </summary>
    [System.Serializable]
    public class InscriptionModel {
        /// <summary>
        /// 符文颜色
        /// </summary>
        public InscriptionColor _inscriptionColor;

        /// <summary>
        /// 符文放置位置ID
        /// </summary>
        public int _inscriptionPosId;

        /// <summary>
        /// 符文Id
        /// </summary>
        public int _inscriptionID;
    }

    /// <summary>
    ///符文页传输模型
    /// </summary>
    [System.Serializable]
    public class InscriptionPageMode {
        
        /// <summary>
        /// 符文页Id
        /// </summary>
        public int _inscriptionPageId;

        /// <summary>
        /// 符文页名称
        /// </summary>
        public string _inscriptionPageName;

        /// <summary>
        /// 符文页的符文
        /// </summary>
        public List<InscriptionModel> _inscriptionModelList;
    }
}