using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InscriptionSystem;
using UnityEngine.UI;

namespace InscriptionSystem.UI
{
    public class InscriptionPageUIController : MonoBehaviour
    {
        private static InscriptionPageUIController instance = null;

        public Sprite nullSprite;

        private void Awake()
        {
            instance = this;
        }

        public static InscriptionPageUIController Instance {
            get {
                return instance;
            }
        }


        private InscriptionSlotButton[] inscriptionButtonList;

        /// <summary>
        /// 符文页Id
        /// </summary>
        private int _pageNumber = 0;

        /// <summary>
        /// 当前符文页
        /// </summary>
        public InscriptionPage inscriptionPage;

        public int PageNumber
        {
            get { return _pageNumber; }
            set
            {
                if (value != _pageNumber)
                {
                    _pageNumber = value;
                    ClearInscription();
                    InitInscriptionSlot();
                    SendMessageToInscriptionPagePanel();
                }
            }
        }

        void Start()
        {
            inscriptionButtonList = transform.GetComponentsInChildren<InscriptionSlotButton>();
            PageNumber = 1;
        }

        /// <summary>
        /// 将对应的符文放入指定的卡插槽中
        /// </summary>
        private void InitInscriptionSlot()
        {
            inscriptionPage = InscriptionPageFactory.Instance.GetInscriptionPageById(_pageNumber);
            for (int i = 0; i < inscriptionButtonList.Length; i++)
            {
                Inscription inscrptionCh=null;
                switch (inscriptionButtonList[i].slotColor)
                {
                    case InscriptionColor.BLUE:
                        if (inscriptionPage.blueInscription.ContainsKey(inscriptionButtonList[i].slotId))
                        {
                            inscrptionCh = inscriptionPage.blueInscription[inscriptionButtonList[i].slotId];
                        }
                        break;
                    case InscriptionColor.GREEN:
                        if (inscriptionPage.greenInscription.ContainsKey(inscriptionButtonList[i].slotId))
                        {
                            inscrptionCh = inscriptionPage.greenInscription[inscriptionButtonList[i].slotId];
                        }
                        break;
                    case InscriptionColor.RED:
                        if (inscriptionPage.redInscription.ContainsKey(inscriptionButtonList[i].slotId))
                        {
                            inscrptionCh = inscriptionPage.redInscription[inscriptionButtonList[i].slotId];
                        }                  
                        break;
                }
                if (inscrptionCh != null)
                {
                    inscriptionButtonList[i].inscriptionId = inscrptionCh.inscriptionID;
                    inscriptionButtonList[i].isInscription = true;
                    inscriptionButtonList[i].GetComponent<Image>().sprite = inscrptionCh.inscriptionIcon;
                }
            }
        }

        /// <summary>
        /// 清除符文页中的符文
        /// </summary>
        private void ClearInscription()
        {
            for (int i = 0; i < inscriptionButtonList.Length; i++)
            {
                inscriptionButtonList[i].inscriptionId = 0;
                inscriptionButtonList[i].isInscription = false;
                inscriptionButtonList[i].GetComponent<Image>().sprite = nullSprite;
            }
        }

        /// <summary>
        /// 按钮响应事件：控制切换符文页
        /// </summary>
        /// <param name="pageNumber"></param>
        public void OnPageChange(int pageNumber) {
            PageNumber = pageNumber;
        }

        /// <summary>
        /// SendMessage事件发送体，当前符文页信息发生给InscriptionPagePanel
        /// </summary>
        private  void SendMessageToInscriptionPagePanel() {
            InscriptionAttribueUIController.Instance.inscriptionPagePanel.SendMessage("OnReciveFromInscriptionPage", inscriptionPage);
        }
    }
}