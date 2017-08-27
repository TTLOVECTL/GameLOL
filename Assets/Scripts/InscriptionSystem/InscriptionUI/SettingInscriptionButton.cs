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

        public Image iocnSprite;

        public Text inscriptionNumber;

        public Text inscriptionName;

        public List<Text> inscriptionAttribute;

        public void OnClickAddInscription()
        {

            InscriptionSlotButton insbu = InscriptionSlotButton.currentButton.GetComponent<InscriptionSlotButton>();

            if (insbu.isInscription) {
                switch (insbu.slotColor)
                {
                    case InscriptionColor.BLUE:
                        InscriptionPageUIController.Instance.inscriptionPage.blueInscription.Remove(insbu.slotId);
                        break;
                    case InscriptionColor.GREEN:
                        InscriptionPageUIController.Instance.inscriptionPage.greenInscription.Remove(insbu.slotId);
                        break;
                    case InscriptionColor.RED:
                        InscriptionPageUIController.Instance.inscriptionPage.redInscription.Remove(insbu.slotId);
                        break;
                }

                InscriptionConst._instriptionBag.Add(insbu.inscriptionId);
            }

            Inscription a = InscriptionFactory.Instance.GetInscriptionById(inscriptionId);

            ///移除背包里已被添加符文
            for (int i = 0; i < InscriptionConst._instriptionBag.Count; i++) {
                if (InscriptionConst._instriptionBag[i] == inscriptionId) {
                    InscriptionConst._instriptionBag.RemoveAt(i);
                }
            }
            
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