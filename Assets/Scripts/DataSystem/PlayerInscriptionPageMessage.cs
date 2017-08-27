using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InscriptionSystem;

namespace DataSystem
{
    public class PlayerInscriptionPageMessage
    {
        private static SortedDictionary<int, InscriptionPageMode> inscriptionPageList = new SortedDictionary<int, InscriptionPageMode>();

        public static SortedDictionary<int, InscriptionPageMode> InscriptionPageList {
            get {
                return inscriptionPageList;
            }
            set {
                inscriptionPageList = value;
            }
        }

        public static void UpdateInscriptionToPage(int page,InscriptionColor inscriptionColor, int soltId,int inscriptionId ) {

            if (!inscriptionPageList.ContainsKey(page)) {
                return;
            }

            //Todo:发送更改或的信息给服务器

            foreach(InscriptionModel item in inscriptionPageList[page]._inscriptionModelList) {
                if (item._inscriptionColor == inscriptionColor && item._inscriptionPosId == soltId) {
                    item._inscriptionID = inscriptionId;
                }
            }

        }

        public static int GetMaxInscriptionNumber(int inscriptionId) {
            int maxNumber = 0;
            foreach (KeyValuePair<int, InscriptionPageMode> item in inscriptionPageList) {
                int temp = 0;
                foreach (InscriptionModel model in item.Value._inscriptionModelList) {
                    if (model._inscriptionID == inscriptionId) {
                        temp++;
                    }
                }
                if (temp > maxNumber) {
                    maxNumber = temp;
                }
            }
            return maxNumber;
        }
    }


    public class InscriptionModel
    {
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
    public class InscriptionPageMode
    {

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
