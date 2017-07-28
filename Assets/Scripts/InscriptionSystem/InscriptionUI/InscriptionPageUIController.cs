using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InscriptionSystem;
using UnityEngine.UI;

namespace InscriptionSystem.UI
{
    public class InscriptionPageUIController : MonoBehaviour
    {
        
        private InscriptionSlotButton[] inscriptionButtonList;

        private int _pageNumber = 0;

        private InscriptionPage inscriptionPage;

        private int PageNumber
        {
            get { return _pageNumber; }
            set
            {
                if (value != _pageNumber)
                {
                    _pageNumber = value;
                    ClearInscription();
                    InitInscriptionSlot();
                }
            }
        }

        void Start()
        {
            inscriptionButtonList = transform.GetComponentsInChildren<InscriptionSlotButton>();
            PageNumber = 1;
        }

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
                    inscriptionButtonList[i].GetComponent<Image>().enabled = true;
                    inscriptionButtonList[i].GetComponent<Image>().sprite = inscrptionCh.inscriptionIcon;

                }
            }
        }

        private void ClearInscription()
        {
            for (int i = 0; i < inscriptionButtonList.Length; i++)
            {
                inscriptionButtonList[i].inscriptionId = 0;
                inscriptionButtonList[i].isInscription = false;
                inscriptionButtonList[i].GetComponent<Image>().enabled = false;
            }
        }

        public void OnPageChange(int pageNumber) {
            PageNumber = pageNumber;
        } 
    }
}