using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace InscriptionSystem
{
    public class CreateInscriptionUI : MonoBehaviour
    {
        public GameObject instance;

        public GameObject contentObj;

        private int inscriptionLevel = 5;

        private AttribueType inscriptionType = AttribueType.ALL;

        private List<Inscription> _inscriptionList;

        private RectTransform contentTransform;

        private float buttonwidth;

        void Start()
        {
            InscriptionHolder ceh = AssetDatabase.LoadAssetAtPath<InscriptionHolder>("Assets/Resources/Inscription.asset");
            if (ceh == null)
            {
                return;
            }
            _inscriptionList = ceh.inscription;
            contentTransform = contentObj.GetComponent<RectTransform>();
            buttonwidth = (GetComponent<RectTransform>().rect.width - 40) / 3;
            ChooseDeal();
        }
        void Update()
        {

        }

        public void OnChooseLevelButton(int level) {
            inscriptionLevel = level;
            ChooseDeal();
        }

        public void OnChooseTypeButtoon(AttribueType type) {
            inscriptionType = type;
            ChooseDeal();
        }

        private void ChooseDeal() {
            List<Inscription> resultList = GetInScription();
            int number = resultList.Count / 3;
            if (resultList.Count % 3 > 0)
            {
                number = resultList.Count / 3 + 1;
            }
            Debug.Log(buttonwidth);
            Debug.Log(number);
            float height = number * buttonwidth / 2 + (number + 1) * 10;
            Debug.Log(height);
            contentTransform.sizeDelta = new Vector2(0, height);
            GameObject ga = Instantiate(instance);
            ga.GetComponent<RectTransform>().sizeDelta = new Vector2(buttonwidth,buttonwidth/2);
            ga.GetComponent<RectTransform>().localPosition = new Vector2(-buttonwidth - 10, 0);
            ga.transform.SetParent(contentObj.transform);
           


        }

        private List<Inscription> GetInScription() {
            List<Inscription> list = new List<Inscription>();
            foreach (Inscription insc in _inscriptionList) {
                if ((insc.inscriptionLevel == inscriptionLevel)&& IsLookInscription(insc)){
                    list.Add(insc);
                }
            }
            return list;
        }

        private bool IsLookInscription(Inscription insca) {
            switch (inscriptionType) {
                case AttribueType.ALL:
                    return true;
                case AttribueType.ATTACK:
                    
                    break;
                case AttribueType.DEFENSE:
                    break;
                case AttribueType.BAOJI:
                    break;
                case AttribueType.PENETRATION:
                    break;
                case AttribueType.SPEED:
                    break;
                case AttribueType.Tool:
                    break;
                case AttribueType.VAMPIRE:
                    break;
            }

            return false;
        }


        private void SetAnchors(RectTransform t) {
            RectTransform pt = t.parent as RectTransform;
            if (t == null || pt == null)
                return;
            t.anchorMin = new Vector2(t.anchorMin.x + t.offsetMin.x / pt.rect.width, t.anchorMin.y + t.offsetMin.y / pt.rect.height);
            t.anchorMax = new Vector2(t.anchorMax.x + t.offsetMax.x / pt.rect.width, t.anchorMax.y + t.offsetMax.y / pt.rect.height);
            t.offsetMin = t.offsetMax = new Vector2(0, 0);
        }
    }
}