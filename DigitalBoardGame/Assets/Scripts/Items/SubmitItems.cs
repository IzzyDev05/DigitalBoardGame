using UnityEngine;
using TMPro;
using OTU.Core;
using OTU.Managers;

namespace OTU.Items {
    public class SubmitItems : MonoBehaviour
    {
        [SerializeField] private int itemsRequired = 5;
        [SerializeField] private GameManager gameManager;

        [Header("UI")]
        [SerializeField] private GameObject submitPrompt;
        [SerializeField] private GameObject totalItemsReqText;
        [SerializeField] private GameObject totalItemsReqAmount;
        [SerializeField] private GameObject totalItemsSubmittedText;
        [SerializeField] private GameObject totalItemsSubmittedAmount;

        private int playerItems = 0;
        private int itemsSubmitted = 0;
        private PlayerHandler player;
        private bool isInVicinity = false;

        private void Start() {
            DisableUI();
        }

        private void Update() {
            if (!isInVicinity) return;

            totalItemsSubmittedAmount.GetComponent<TextMeshProUGUI>().text = itemsSubmitted.ToString();

            if (Input.GetKeyDown(KeyCode.E)) {
                playerItems = player.GetTotalItems();
                itemsSubmitted += playerItems;
                player.RemoveItems();

                if (itemsSubmitted >= itemsRequired) {
                    gameManager.GameWon();
                }
                else {
                    int itemsLeft = itemsSubmitted - playerItems;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (!other.CompareTag("Player")) return;
            isInVicinity = true;
            player = other.GetComponent<PlayerHandler>();

            submitPrompt.SetActive(true);
            totalItemsReqText.SetActive(true);
            totalItemsReqAmount.SetActive(true);
            totalItemsSubmittedText.SetActive(true);
            totalItemsSubmittedAmount.SetActive(true);

            totalItemsReqAmount.GetComponent<TextMeshProUGUI>().text = itemsRequired.ToString();
        }

        private void OnTriggerExit2D(Collider2D other) {
            player = null;
            DisableUI();
        }

        private void DisableUI() {
            submitPrompt.SetActive(false);
            totalItemsReqText.SetActive(false);
            totalItemsReqAmount.SetActive(false);
            totalItemsSubmittedText.SetActive(false);
            totalItemsSubmittedAmount.SetActive(false);
        }
    }
}