using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DataSystem
{
    /// <summary>
    /// 玩家基本信息存储
    /// </summary>
    public class PlayerBaseMessage
    {
        private static int playerId;

        private static string playerName = "监控打开";

        private static int playerLeve = 29;

        private static int currentExperence = 1000;

        private static int headImage = 1;

        private static int goldNumbere = 500000;

        private static int diamondsNumber = 500000;

        private static int volumeNumber = 500000;

        private static int inscriptionNumber = 500000;

        public static int PlayerId {
            get {
                return playerId;
            }
            set {
                playerId = value;
            }
        }

        /// <summary>
        /// 玩家昵称
        /// </summary>
        public static string PlayerName {
            get {
                return playerName;
            }
            set {
                if (value != playerName) {
                    //Todo:发送更改信息给服务器
                    playerName = value;
                }
            }
        }

        /// <summary>
        /// 玩家等级
        /// </summary>
        public static int PlayerLevel {
            get {
                return playerLeve;
            }

            set {
                if (playerLeve != value) {
                    playerLeve = value;
                    //Todo:发送更改数据给服务器
                }
            }
        }
       
        /// <summary>
        /// 玩家当前等级经验
        /// </summary>
        public static int CurrentExperence {
            get {
                return currentExperence;
            }
            set {
                if (currentExperence != value) {
                    currentExperence = value;
                    //Todo:发生更改数据服务器
                }
            }
        }

        /// <summary>
        /// 玩家当前头像框ID
        /// </summary>
        public static int HeadImage {
            get {
                return headImage;
            }
            set {
                if (headImage != value) {
                    headImage = value;
                }
            }
        }

        /// <summary>
        /// 玩家当前金币数量
        /// </summary>
        public static int GoldNumbere {
            get {
                return goldNumbere;
            }

            set {
                if (goldNumbere != value) {
                    goldNumbere = value;
                }
            }

        }

        /// <summary>
        /// 玩家当前钻石数量
        /// </summary>
        public static int DiamondsNumber {
            get {
                return diamondsNumber;
            }
            set {
                if (diamondsNumber != value) {
                    diamondsNumber = value;
                }
            }
        }

        /// <summary>
        /// 玩家当前点券数量
        /// </summary>
        public static int VolumeNumber {
            get {
                return volumeNumber;
            }

            set {
                if (value != volumeNumber)
                {

                    volumeNumber = value;
                }
            }
        }

        /// <summary>
        /// 玩家当前符文碎片数量
        /// </summary>
        public static int InscriptionNumber {
            get {
                return inscriptionNumber;
            }

            set {
                if (inscriptionNumber != value) {
                    inscriptionNumber = value;
                }
            }
        }


    }
}
