using UnityEngine;
using TMPro;
using OTU.Managers;

namespace OTU.UI {
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private GameObject inventoryPanel;
        [SerializeField] private PlayerHandler[] players;
        [SerializeField] private TextMeshProUGUI[] playerNames;
        [SerializeField] private TextMeshProUGUI[] playerItems;

        private bool showInventory = false;
        private bool changedPlayerNames = false;
        private PlayerUsernames playerUsernames;
        private InitializePlayers initializePlayers;

        private void Start() {
            inventoryPanel.SetActive(false);
            playerUsernames = FindObjectOfType<PlayerUsernames>();
            initializePlayers = FindObjectOfType<InitializePlayers>();
        }

        private void Update() {
            SetPlayerNames();

            if (Input.GetKeyDown(KeyCode.Tab)) {
                showInventory = !showInventory;
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

                changedPlayerNames = true;
            }
        }

        private void SetPlayerItemsAmount() {
            playerItems[0].text = players[0].GetTotalItems().ToString();
            playerItems[1].text = players[1].GetTotalItems().ToString();
            playerItems[2].text = players[2].GetTotalItems().ToString();
            playerItems[3].text = players[3].GetTotalItems().ToString();
        }
    }
}