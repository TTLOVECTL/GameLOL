using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataSystem;
using InscriptionSystem.UI;
using InscriptionSystem;


namespace InscriptionSystem.UI
{
    public class InscriptionPageChoose : MonoBehaviour
    {

        private Dropdown inscriptionPageChooseDropDown;
        // Use this for initialization
        void Start()
        {
            inscriptionPageChooseDropDown = GetComponent<Dropdown>();
            SetOptionName();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void SetOptionName()
        {
            if (PlayerInscriptionPageMessage.InscriptionPageList.ContainsKey(1))
            {
                inscriptionPageChooseDropDown.options[0].text = PlayerInscriptionPageMessage.InscriptionPageList[1]._inscriptionPageName;
            }
            if (PlayerInscriptionPageMessage.InscriptionPageList.ContainsKey(2))
            {
                inscriptionPageChooseDropDown.options[1].text = PlayerInscriptionPageMessage.InscriptionPageList[2]._inscriptionPageName;
            }
            if (PlayerInscriptionPageMessage.InscriptionPageList.ContainsKey(3))
            {
                inscriptionPageChooseDropDown.options[2].text = PlayerInscriptionPageMessage.InscriptionPageList[3]._inscriptionPageName;
            }

        }

        public void OnChangeInscriptionPage()
        {
            if (!PlayerInscriptionPageMessage.InscriptionPageList.ContainsKey(inscriptionPageChooseDropDown.value + 1))
            {
                //PlayerInscriptionPageMessage.InscriptionPageList.Add(inscriptionPageChooseDropDown.value+1,new i)
                InscriptionPageFactory.Instance.AddNewInscripttion(inscriptionPageChooseDropDown.value + 1, new InscriptionPage());
                PlayerInscriptionPageMessage.InscriptionPageList.Add(inscriptionPageChooseDropDown.value + 1, InscriptionPageChoose.InitNewInscriptionPage(inscriptionPageChooseDropDown.value + 1));
            }
            InscriptionAttribueUIController.Instance.inscriptionPagePanel.SetActive(true);
            InscriptionAttribueUIController.Instance.inscriptionAttributePanel.SetActive(false);
            InscriptionAttribueUIController.Instance.inscriptionSettingPanel.SetActive(true);
            InscriptionPageUIController.Instance.PageNumber = inscriptionPageChooseDropDown.value + 1;
        }

        public static InscriptionPageMode InitNewInscriptionPage(int inscriptionPageId) {
            InscriptionPageMode inscriptionPageModle = new InscriptionPageMode();
            inscriptionPageModle._inscriptionPageId = inscriptionPageId;
            inscriptionPageModle._inscriptionPageName = "符文页" + inscriptionPageId.ToString();
            inscriptionPageModle._inscriptionModelList = new List<InscriptionModel>();
            return inscriptionPageModle;

        }
    }
}