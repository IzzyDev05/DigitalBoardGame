using System.Collections.Generic;
using UnityEngine;
using TMPro;
using OTU.Core;
using OTU.Managers;
using OTU.Inventory;

namespace OTU.Items {
    public class SubmitItems : MonoBehaviour
    {
        [SerializeField] private int itemsRequired = 5;
        [SerializeField] private int nutsRequired = 3;
        [SerializeField] private int fuelRequired = 2;
        [SerializeField] private GameManager gameManager;

        [Header("UI")]
        [SerializeField] private GameObject submitPrompt;
        [SerializeField] private GameObject totalItemsReqText;
        [SerializeField] private GameObject totalItemsReqAmount;
        [SerializeField] private GameObject totalItemsSubmittedText;
        [SerializeField] private GameObject totalItemsSubmittedAmount;

        private int itemsSubmitted = 0;
        private PlayerHandler player;
        private bool isInVicinity = false;


        private List<ItemsSO> items;
        private int numberOfNuts;
        private int amountOfFuel;
        private int nutsSubmitted;
        private int fuelSubmitted;

        private void Start() {
            DisableUI();
        }

        private void Update() {
            if (!isInVicinity) return;

            totalItemsSubmittedAmount.GetComponent<TextMeshProUGUI>().text = itemsSubmitted.ToString();

            if (Input.GetKeyDown(KeyCode.E))
            {
                Submit();
            }
        }

        private void Submit() {
            items = player.GetTotalItemsX();
            foreach (ItemsSO item in items) {
                if (item.itemType == ItemsSO.ItemType.nutsAndBolts) {
                    numberOfNuts++;
                }
                else if (item.itemType == ItemsSO.ItemType.nutsAndBolts) {
                    amountOfFuel++;
                }
            }

            nutsSubmitted += numberOfNuts;
            fuelSubmitted += amountOfFuel;
            player.RemoveActualItems();
            numberOfNuts = 0;
            amountOfFuel = 0;

            if (nutsSubmitted + fuelSubmitted >= nutsRequired + fuelRequired) {
                gameManager.GameWon();
            }
            else {
                int nutsLeft = nutsRequired - nutsSubmitted;
                int boltsLeft = fuelRequired - fuelSubmitted;

                print("Nuts left: " + nutsLeft);
                print("Bolts left: " + boltsLeft);
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