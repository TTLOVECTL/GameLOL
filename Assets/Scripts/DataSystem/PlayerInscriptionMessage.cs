using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataSystem {
    public class PlayerInscriptionMessage {


        private static SortedDictionary<int, InscriptionMessage> inscriptionList = new SortedDictionary<int, InscriptionMessage>();

        public static SortedDictionary<int,InscriptionMessage> InscriptionList {
            get {
                return inscriptionList;
            }
            set {
                inscriptionList = value;
            }
        }

        /// <summary>
        /// 获得新的符文
        /// </summary>
        /// <param name="inscriptionid"></param>
        public static void AddInscritonToBag(int inscriptionid) {
            //Todo:发送更新信息给服务器
            if (inscriptionList.ContainsKey(inscriptionid))
            {
                inscriptionList[inscriptionid].inscriptionNumber += 1;
            }
            else {
                InscriptionMessage inscriptionMessage = new InscriptionMessage();
                inscriptionMessage.inscriptionNumber = 1;
                inscriptionMessage.inscriptionId = inscriptionid;
                inscriptionList.Add(inscriptionid, inscriptionMessage);
            }
        }

        /// <summary>
        /// 移除符文
        /// </summary>
        /// <param name="inscriptionid"></param>
        public static void RemoveInscriptionFromBag(int inscriptionid) {
            //Todo:发送更新的数据给服务器
            if (!inscriptionList.ContainsKey(inscriptionid)) {
                return;
            }
            InscriptionMessage inscriptionMessage = inscriptionList[inscriptionid];
            if (inscriptionMessage.inscriptionUseNumber < inscriptionMessage.inscriptionNumber)
            {
                inscriptionMessage.inscriptionNumber -= 1;
                if (inscriptionMessage.inscriptionNumber == 0)
                {
                    inscriptionList.Remove(inscriptionid);
                }
            }
        }

        /// <summary>
        /// 获取所有背包未使用的铭文
        /// </summary>
        /// <returns></returns>
        public static List<InscriptionMessage> GetNoUseInscription() {
            List<InscriptionMessage> inscriptionMessageList = new List<InscriptionMessage>();
            foreach (KeyValuePair<int, InscriptionMessage> item in inscriptionList) {
                if (item.Value.inscriptionUseNumber < item.Value.inscriptionNumber) {
                    inscriptionMessageList.Add(item.Value);
                }
            }
            return inscriptionMessageList;
        }
    }

    public class InscriptionMessage {
        public int inscriptionId;
        public int inscriptionNumber;
        public int inscriptionUseNumber;
    }
}