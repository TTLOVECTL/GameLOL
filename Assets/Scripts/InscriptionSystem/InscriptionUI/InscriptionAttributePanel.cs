using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InscriptionSystem;
using UnityEngine.UI;

namespace InscriptionSystem.UI {
    /// <summary>
    /// 当个符文属性显示面板
    /// </summary>
    public class InscriptionAttributePanel : MonoBehaviour {

        /// <summary>
        /// 符文显示图标设置
        /// </summary>
        public Image inscriptionsprite;

        /// <summary>
        /// 符文属性显示设置
        /// </summary>
        public Text attributeText;

        public Text inscriptionName;

        /// <summary>
        /// SendMessage接受体：接受来自InscriptionAttribueUIController类发来的信息
        /// </summary>
        /// <param name="insc"></param>
        public void OnReceiveMessage(Inscription insc) {
            inscriptionsprite.sprite = insc._inscriptionIcon;
            inscriptionName.text += (insc.inscriptionLevel+"级符文:"+insc.inscriptionName);
            attributeText.text = "";
            foreach (InscriptionAttribute a in insc._inscriptionAttribute) {
                string text = a.attributeName;
                if (a.valueType == AttributeValue.NUMBER)
                {
                    text += a._attributeValue.ToString();
                }
                else {
                    text += ((a._attributeValue * 100).ToString() + "%");
                }
                attributeText.text += text;
                attributeText.text += "\n";
            }
        }

        /// <summary>
        /// 按钮响应事件：移除卡槽中的符文
        /// </summary>
        public void OnRemoveInscripteFromSlot() {
            InscriptionSlotButton insbu = InscriptionSlotButton.currentButton.GetComponent<InscriptionSlotButton>();
            
            InscriptionSlotButton.currentButton.GetComponent<Image>().enabled = false;
            insbu.isInscription = false;
            switch (insbu.slotColor)
            {
                case InscriptionColor.BLUE:
                    InscriptionPageUIController.Instance.inscriptionPage.blueInscription.Remove(insbu.inscriptionId);
                    break;
                case InscriptionColor.GREEN:
                    InscriptionPageUIController.Instance.inscriptionPage.greenInscription.Remove(insbu.inscriptionId);
                    break;
                case InscriptionColor.RED:
                    InscriptionPageUIController.Instance.inscriptionPage.redInscription.Remove(insbu.inscriptionId);
                    break;
            }

            InscriptionConst._instriptionBag.Add(insbu.inscriptionId);
            insbu.inscriptionId = 0;

            ///===============================================
            //当移除符文是需要将移除后的数据提交给服务器
            //this.gameObject.SetActive(false);
            //InscriptionAttribueUIController.Instance.inscriptionPagePanel.SetActive(true);
            //InscriptionAttribueUIController.Instance.inscriptionPagePanel.SendMessage("OnReciveFromInscriptionPage", InscriptionPageUIController.Instance.inscriptionPage);
            this.gameObject.SetActive(false);
            InscriptionAttribueUIController.Instance.inscriptionSettingPanel.SetActive(true);
            InscriptionAttribueUIController.Instance.inscriptionSettingPanel.SendMessage("OnReceiveMessage");
        }

        /// <summary>
        /// 按钮响应事件：替换卡槽中的符文
        /// </summary>
        public void OnReplaceInscription() {
            this.gameObject.SetActive(false);
            InscriptionAttribueUIController.Instance.inscriptionSettingPanel.SetActive(true);
            ///SendMessage接受体：发送给InscriptionSettingPanel
            InscriptionAttribueUIController.Instance.inscriptionSettingPanel.SendMessage("OnReceiveMessage");
        }
    }
}
