using System.Collections.Generic;
using UnityEngine;
using TMPro;
using OTU.Core;
using OTU.Managers;
using OTU.Inventory;
using OTU.Movement;
using OTU.UI;

namespace OTU.Items {
    public class SubmitItems : MonoBehaviour
    {
        [SerializeField] private int screwsRequired = 3;
        [SerializeField] private int fuelRequired = 2;
        [SerializeField] private int woodRequired = 5;
        [SerializeField] private int rubberRequired = 3;

        [Header("UI")]
        [SerializeField] private GameObject submitPrompt;
        [SerializeField] private GameObject submitMenu;
        [SerializeField] private TextMeshProUGUI[] itemsReq;
        [SerializeField] private TextMeshProUGUI[] itemsSubmittedAmount;

        private PlayerHandler player;
        private GameManager gameManager;
        private GameObject[] interfaces;
        private List<ItemsSO> items;

        private int itemsSubmitted = 0;
        private int amountOfScrews;
        private int amountOfFuel;
        private int amountOfWood;
        private int amountOfRubber;
        private int screwsSubmitted;
        private int fuelSubmitted;
        private int woodSubmitted;
        private int rubberSubmitted;
        private bool isInVicinity = false;
        private bool showMenu = false;

        private AudioManager audioManager;

        private void Start() {
            audioManager = FindObjectOfType<AudioManager>();
            gameManager = FindObjectOfType<GameManager>();
            interfaces = gameManager.interfaces;
            DisableUI();

            itemsReq[0].text = screwsRequired.ToString();
            itemsReq[1].text = fuelRequired.ToString();
            itemsReq[2].text = woodRequired.ToString();
            itemsReq[3].text = rubberRequired.ToString();
        }

        private void Update() {
            if (!isInVicinity || player == null) return;

            if (Input.GetKeyDown(KeyCode.E) && player.GetComponent<PlayerMovement>().enabled)
            {
                GameManager.IsMenuOpen = !GameManager.IsMenuOpen;
                showMenu = !showMenu;
                submitPrompt.SetActive(false);
                InventoryUI.CanShowInventory = false;

                foreach (GameObject obj in interfaces) {
                    if (obj != this.gameObject) {
                        obj.SetActive(false);
                    }
                }
            }

            submitMenu.SetActive(showMenu);

            itemsSubmittedAmount[0].text = screwsSubmitted.ToString();
            itemsSubmittedAmount[1].text = fuelSubmitted.ToString();
            itemsSubmittedAmount[2].text = woodSubmitted.ToString();
            itemsSubmittedAmount[3].text = rubberSubmitted.ToString();
        }

        public void Submit() {
            audioManager.Play("Click");
            amountOfScrews = player.GetTotalScrews();
            amountOfFuel = player.GetTotalFuel();
            amountOfWood = player.GetTotalWood();
            amountOfRubber = player.GetTotalRubber();

            screwsSubmitted += amountOfScrews;
            fuelSubmitted += amountOfFuel;
            woodSubmitted += amountOfWood;
            rubberSubmitted += amountOfRubber; 

            player.RemoveItems();
            amountOfScrews = 0;
            amountOfFuel = 0;
            amountOfWood = 0;
            amountOfRubber = 0;

            if (screwsSubmitted >= screwsRequired && fuelSubmitted >= fuelRequired && woodSubmitted >= woodRequired && rubberSubmitted >= rubberRequired) {
                gameManager.GameWon();
            }
        }

        public void Back() {
            audioManager.Play("Click");
            GameManager.IsMenuOpen = false;
            showMenu = false;
            DisableUI();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (!other.GetComponent<PlayerMovement>().enabled) return;

            isInVicinity = true;
            player = other.GetComponent<PlayerHandler>();

            submitPrompt.SetActive(true);
        }

        private void OnTriggerStay2D(Collider2D other) {
            if (!other.GetComponent<PlayerMovement>().enabled) 
                player = null;
            else 
                player = other.GetComponent<PlayerHandler>();
        }

        private void OnTriggerExit2D(Collider2D other) {
            player = null;
            isInVicinity = false;
            DisableUI();
        }

        private void DisableUI() {
            submitPrompt.SetActive(false);
            submitMenu.SetActive(false);
            InventoryUI.CanShowInventory = true;
        }
    }
}