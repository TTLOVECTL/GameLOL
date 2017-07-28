
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InscriptionSystem;
namespace InscriptionSystem.UI
{
    /// <summary>
    /// 符文卡槽UI
    /// </summary>
    public class InscriptionSlotButton : MonoBehaviour
    {
        /// <summary>
        /// 当前选中的卡槽物体
        /// </summary>
        public static GameObject currentButton;

        /// <summary>
        /// 卡槽Id
        /// </summary>
        public int  slotId;

        /// <summary>
        /// 卡槽对应设置符文的颜色
        /// </summary>
        public InscriptionColor slotColor;

        /// <summary>
        /// 卡槽含有的符文Id
        /// </summary>
        public int inscriptionId=0;

        /// <summary>
        /// 卡槽是否含有符文
        /// </summary>
        public bool isInscription = false;

        /// <summary>
        /// 按钮响应事件：响应符文按钮
        /// </summary>
        public void OnInscriptionCheack() {
            currentButton = this.gameObject;
            if (isInscription)
            {
                if (inscriptionId != 0)
                {
                    InscriptionAttribueUIController.Instance.gameObject.SendMessage("OnReciveInscriptionMessage", InscriptionFactory.Instance.GetInscriptionById(inscriptionId));
                }
            }
            else {
                InscriptionAttribueUIController.Instance.gameObject.SendMessage("OnReciveSettingInscription",this.gameObject);

            }
        }

    }
}
