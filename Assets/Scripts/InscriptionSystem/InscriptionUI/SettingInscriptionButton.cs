using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InscriptionSystem;
using UnityEngine.UI;
namespace InscriptionSystem.UI
{

    public class SettingInscriptionButton : MonoBehaviour
    {

        public int inscriptionId;

        public void OnClickAddInscription()
        {

            InscriptionSlotButton insbu = InscriptionSlotButton.currentButton.GetComponent<InscriptionSlotButton>();
            Inscription a = InscriptionFactory.Instance.GetInscriptionById(inscriptionId);
            InscriptionConst._instriptionBag.Remove(inscriptionId);
            insbu.GetComponent<Image>().enabled = true;
            insbu.GetComponent<Image>().sprite = a._inscriptionIcon;
            insbu.inscriptionId = inscriptionId;
            insbu.isInscription = true;
            switch (a._inscriptionColor) {
                case InscriptionColor.BLUE:
                    InscriptionPageUIController.Instance.inscriptionPage.SetBlueInsciption(a,insbu.slotId);
                    break;
                case InscriptionColor.GREEN:
                    InscriptionPageUIController.Instance.inscriptionPage.SetGreenInscription(a, insbu.slotId);
                    break;
                case InscriptionColor.RED:
                    InscriptionPageUIController.Instance.inscriptionPage.SetRedInscription(a, insbu.slotId);
                    break;
            }
            //测试
            InscriptionAttribueUIController.Instance.inscriptionSettingPanel.SetActive(false);
            InscriptionAttribueUIController.Instance.inscriptionPagePanel.SetActive(true);
            InscriptionAttribueUIController.Instance.inscriptionPagePanel.SendMessage("OnReciveFromInscriptionPage", InscriptionPageUIController.Instance.inscriptionPage);

        }
    }
}