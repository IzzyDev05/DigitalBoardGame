using System.Collections.Generic;
using UnityEngine;
using TMPro;
using OTU.Core;
using OTU.Managers;
using OTU.Inventory;

namespace OTU.Items {
    public class SubmitItems : MonoBehaviour
    {
        [SerializeField] private int nutsRequired = 3;
        [SerializeField] private int fuelRequired = 2;
        [SerializeField] private int woodRequired = 5;

        [Header("UI")]
        [SerializeField] private GameObject submitPrompt;
        [SerializeField] private GameObject submitMenu;
        [SerializeField] private TextMeshProUGUI[] itemsReq;
        [SerializeField] private TextMeshProUGUI[] itemsSubmittedAmount;

        private PlayerHandler player;
        private GameManager gameManager;
        private List<ItemsSO> items;

        private int itemsSubmitted = 0;
        private int numberOfNuts;
        private int amountOfFuel;
        private int amountOfWood;
        private int nutsSubmitted;
        private int fuelSubmitted;
        private int woodSubmitted;
        private bool isInVicinity = false;

        private AudioManager audioManager;

        private void Start() {
            audioManager = FindObjectOfType<AudioManager>();
            gameManager = FindObjectOfType<GameManager>();
            DisableUI();

            itemsReq[0].text = nutsRequired.ToString();
            itemsReq[1].text = fuelRequired.ToString();
            itemsReq[2].text = woodRequired.ToString();
        }

        private void Update() {
            if (!isInVicinity) return;

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.IsMenuOpen = !GameManager.IsMenuOpen;
                submitPrompt.SetActive(false);
            }

            submitMenu.SetActive(GameManager.IsMenuOpen);

            itemsSubmittedAmount[0].text = nutsSubmitted.ToString();
            itemsSubmittedAmount[1].text = fuelSubmitted.ToString();
            itemsSubmittedAmount[2].text = woodSubmitted.ToString();
        }

        public void Submit() {
            audioManager.Play("Click");
            numberOfNuts = player.GetTotalNuts();
            amountOfFuel = player.GetTotalFuel();
            amountOfWood = player.GetTotalWood();

            nutsSubmitted += numberOfNuts;
            fuelSubmitted += amountOfFuel;
            woodSubmitted += amountOfWood;

            player.RemoveItems();
            numberOfNuts = 0;
            amountOfFuel = 0;
            amountOfWood = 0;

            if (nutsSubmitted >= nutsRequired && fuelSubmitted >= fuelRequired && woodSubmitted >= woodRequired) {
                gameManager.GameWon();
            }
            else {
                int nutsLeft = nutsRequired - nutsSubmitted;
                int boltsLeft = fuelRequired - fuelSubmitted;
                int woodLeft = woodRequired - woodSubmitted;
            }
        }

        public void Back() {
            audioManager.Play("Click");
            GameManager.IsMenuOpen = !GameManager.IsMenuOpen;
            DisableUI();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (!other.CompareTag("Player")) return;
            isInVicinity = true;
            player = other.GetComponent<PlayerHandler>();

            submitPrompt.SetActive(true);
        }

        private void OnTriggerExit2D(Collider2D other) {
            player = null;
            isInVicinity = false;
            DisableUI();
        }

        private void DisableUI() {
            submitPrompt.SetActive(false);
            submitMenu.SetActive(false);
        }
    }
}