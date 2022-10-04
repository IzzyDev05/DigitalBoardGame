using System.Collections.Generic;
using UnityEngine;
using TMPro;
using OTU.Core;
using OTU.Managers;
using OTU.Inventory;

namespace OTU.UI {
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private GameObject inventoryPanel;
        [SerializeField] private PlayerHandler[] players;
        [SerializeField] private TextMeshProUGUI[] playerNames;

        [SerializeField] private GameObject[] playerPanels;
        [SerializeField] private TextMeshProUGUI[] nutsAmount;
        [SerializeField] private TextMeshProUGUI[] fuelAmount;
        [SerializeField] private TextMeshProUGUI[] woodAmount;

        [SerializeField] private TextMeshProUGUI[] playerSwitchesNames;

        private GameManager gameManager;
        private GameObject[] interfaces;
        private AudioManager audioManager;
        private PlayerUsernames playerUsernames;
        private InitializePlayers initializePlayers;
        private List<ItemsSO> items = new List<ItemsSO>();

        private bool showInventory = false;
        private bool changedPlayerNames = false;

        private void Start() {
            audioManager = FindObjectOfType<AudioManager>();
            gameManager = FindObjectOfType<GameManager>();
            interfaces = gameManager.interfaces;
            inventoryPanel.SetActive(false);
            playerUsernames = FindObjectOfType<PlayerUsernames>();
            initializePlayers = FindObjectOfType<InitializePlayers>();
        }

        private void Update() {
            SetPlayerNames();

            if (Input.GetKeyDown(KeyCode.Tab)) {
                showInventory = !showInventory;
                GameManager.IsMenuOpen = !GameManager.IsMenuOpen;

                foreach (GameObject obj in interfaces) {
                    if (obj != this.gameObject) {
                        obj.SetActive(false);
                    }
                }
            }

            inventoryPanel.SetActive(showInventory);

            SetPlayerItemsAmount();
        }

        private void SetPlayerNames() {
            if (initializePlayers.arePlayersNamed && !changedPlayerNames) {
                playerNames[0].text = playerUsernames.username1;
                playerNames[1].text = playerUsernames.username2;
                playerNames[2].text = playerUsernames.username3;
                playerNames[3].text = playerUsernames.username4;

                playerSwitchesNames[0].text = playerUsernames.username1;
                playerSwitchesNames[1].text = playerUsernames.username2;
                playerSwitchesNames[2].text = playerUsernames.username3;
                playerSwitchesNames[3].text = playerUsernames.username4;

                changedPlayerNames = true;
            }
        }

        private void SetPlayerItemsAmount() {
            Nuts();
            Fuel();
            Wood();
        }

        private void Nuts() {
            for (int i = 0; i < playerNames.Length; i++) {
                nutsAmount[i].text = players[i].GetTotalNuts().ToString();
            }
        }

        private void Fuel() {
            for (int i = 0; i < playerNames.Length; i++) {
                fuelAmount[i].text = players[i].GetTotalFuel().ToString();
            }
        }

        private void Wood() {
            for (int i = 0; i < playerNames.Length; i++) {
                woodAmount[i].text = players[i].GetTotalWood().ToString();
            }
        }

        public void SwitchPlayer1() {
            audioManager.Play("Click");
            playerPanels[0].SetActive(true);
            playerPanels[1].SetActive(false);
            playerPanels[2].SetActive(false);
            playerPanels[3].SetActive(false);
        }

        public void SwitchPlayer2() {
            audioManager.Play("Click");
            playerPanels[0].SetActive(false);
            playerPanels[1].SetActive(true);
            playerPanels[2].SetActive(false);
            playerPanels[3].SetActive(false);
        }

        public void SwitchPlayer3() {
            audioManager.Play("Click");
            playerPanels[0].SetActive(false);
            playerPanels[1].SetActive(false);
            playerPanels[2].SetActive(true);
            playerPanels[3].SetActive(false);            
        }

        public void SwitchPlayer4() {
            audioManager.Play("Click");
            playerPanels[0].SetActive(false);
            playerPanels[1].SetActive(false);
            playerPanels[2].SetActive(false);
            playerPanels[3].SetActive(true);            
        }
    }
}