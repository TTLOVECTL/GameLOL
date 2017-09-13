using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataSystem;
namespace ControllerSystem
{
    public class MainSceneDataController : MonoBehaviour
    {

        public Text goldText;

        public Text diamondsText;

        public Text volumeText;

        public Text playerNameText;

        public Text playerLevelText;
        // Use this for initialization
        void Start()
        {
            InitPlayerData();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void InitPlayerData()
        {
            goldText.text = PlayerBaseMessage.GoldNumbere.ToString();
            diamondsText.text = PlayerBaseMessage.DiamondsNumber.ToString();
            volumeText.text = PlayerBaseMessage.VolumeNumber.ToString();
            playerNameText.text = PlayerBaseMessage.PlayerName;
            playerLevelText.text ="LV"+ PlayerBaseMessage.PlayerLevel.ToString();
        }
    }
}