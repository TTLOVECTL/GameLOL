using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InscriptionSystem;
namespace InscriptionSystem.UI
{
    public class InscriptionAttribueUIController : MonoBehaviour
    {
        /// <summary>
        /// 实例化唯一的对象
        /// </summary>
        private  static InscriptionAttribueUIController instance = null;

        private void Awake()
        {
            if (instance == null) {
                instance = this;
            }
        }

        /// <summary>
        /// 获取唯一的对象
        /// </summary>
        public static InscriptionAttribueUIController Instance{
            get {
                return instance;
            }
        }

        /// <summary>
        /// 符文属性面板
        /// </summary>
        public GameObject inscriptionAttributePanel;

        /// <summary>
        /// 符文页属性面板
        /// </summary>
        public GameObject inscriptionPagePanel;

        /// <summary>
        /// 设置符文槽面板
        /// </summary>
        public GameObject inscriptionSettingPanel;


        private void Start()
        {

            inscriptionPagePanel.SetActive(true);
        }

        /// <summary>
        /// SendMessage接受体：接受来自InscriptionSlotButton，用于是指符文属性面板信息
        /// </summary>
        /// <param name="insc"></param>
        public void OnReciveInscriptionMessage(Inscription insc)
        {
            inscriptionSettingPanel.SetActive(false);
            inscriptionPagePanel.SetActive(false);
            inscriptionAttributePanel.SetActive(true);
            
            inscriptionAttributePanel.SendMessage("OnReceiveMessage",insc);

        }

        /// <summary>
        ///  SendMessage接受体：接受来自InscriptionSlotButton，用于是指符文设置面板信息
        /// </summary>
        /// <param name="ga"></param>
        public void OnReciveSettingInscription(GameObject ga)
        {
            inscriptionSettingPanel.SetActive(true);
            inscriptionPagePanel.SetActive(false);
            inscriptionAttributePanel.SetActive(false);
            ///SendMessage接受体：发送给InscriptionSettingPanel
            inscriptionSettingPanel.SendMessage("OnReceiveMessage");
        }

        /// <summary>
        /// HAVE many proplem toSolve
        /// </summary>
        /// <param name="inscriptionPage"></param>
        public void OnReciveInscriptionPage(InscriptionPage inscriptionPage)
        {
            inscriptionSettingPanel.SetActive(false);
            inscriptionPagePanel.SetActive(true);
            inscriptionAttributePanel.SetActive(false);
        }
    }
}
