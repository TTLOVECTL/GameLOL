using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EquipmentSystem;
using UnityEngine.UI;

namespace EquipmentSystem.UI
{
    public class EquipmentAttributePanel : MonoBehaviour
    {
        public Image iconImage;

        public Text attributeText;

        public void OnReciveMessgaeEquipmentButton() {
            attributeText.text = "";
            EquipmentButton eqb = EquipmentButton.currentEquipmentButton.GetComponent<EquipmentButton>();
            switch (eqb.equipmentType) {
                case EqunipmentType.SMALL:
                    EquipmentLeaf eleaf = EquipmentFactory.Instance.GetLeafEquipmentById(eqb.equipemntId);
                    if (eleaf != null) {
                        iconImage.sprite = eleaf.equipmentIcor;
                        foreach (EquipmentAttribute item in eleaf.equipmentAttribute) {
                            attributeText.text += (item._attributeName + ":");
                            string valuestring = "";
                            switch (item._attributeType) {
                                case InscriptionSystem.AttributeValue.NUMBER:
                                    valuestring = System.Math.Round(item._attributeValue, 1).ToString();
                                    break;
                                case InscriptionSystem.AttributeValue.PERCENTAGE:
                                    valuestring = System.Math.Round(item._attributeValue * 100, 1).ToString() + "%";
                                    break;
                            }
                            attributeText.text += valuestring;
                        }
                    }
                    break;
                case EqunipmentType.MIDDLE:
                    EquipmentComponent ecomp = EquipmentFactory.Instance.GetMiddleEquipmentById(eqb.equipemntId);
                    if (ecomp != null)
                    {
                        iconImage.sprite = ecomp.equipmentIcor;
                        foreach (EquipmentAttribute item in ecomp.equipmentAttribute)
                        {
                            attributeText.text += (item._attributeName + ":");
                            string valuestring = "";
                            switch (item._attributeType)
                            {
                                case InscriptionSystem.AttributeValue.NUMBER:
                                    valuestring = System.Math.Round(item._attributeValue, 1).ToString();
                                    break;
                                case InscriptionSystem.AttributeValue.PERCENTAGE:
                                    valuestring = System.Math.Round(item._attributeValue * 100, 1).ToString() + "%";
                                    break;
                            }
                            attributeText.text += valuestring;
                        }
                    }
                    
                    break;
                case EqunipmentType.BIG:
                    EquipmentComponent bigecomp = EquipmentFactory.Instance.GetBigEquipmentById(eqb.equipemntId);
                    if (bigecomp != null)
                    {
                        iconImage.sprite = bigecomp.equipmentIcor;
                        foreach (EquipmentAttribute item in bigecomp.equipmentAttribute)
                        {
                            attributeText.text += (item._attributeName + ":");
                            string valuestring = "";
                            switch (item._attributeType)
                            {
                                case InscriptionSystem.AttributeValue.NUMBER:
                                    valuestring = System.Math.Round(item._attributeValue, 1).ToString();
                                    break;
                                case InscriptionSystem.AttributeValue.PERCENTAGE:
                                    valuestring = System.Math.Round(item._attributeValue * 100, 1).ToString() + "%";
                                    break;
                            }
                            attributeText.text += valuestring;
                        }
                    }

                    break;
            }
        }
    }
}