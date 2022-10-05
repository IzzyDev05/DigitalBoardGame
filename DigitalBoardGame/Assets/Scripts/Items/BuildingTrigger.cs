using UnityEngine;
using TMPro;
using OTU.Core;
using OTU.Managers;
using OTU.Inventory;
using OTU.Movement;
using OTU.UI;

namespace OTU.Items {
    public class BuildingTrigger : MonoBehaviour 
    {
        [Range(0, 100)][SerializeField] private int chanceOfGettingItems = 50;
        [SerializeField] private ItemsSO itemType;
        [SerializeField] private int loseTurns = 2;
        
        [Space(20)]
        [SerializeField] private GameObject searchPromptText;
        [SerializeField] private GameObject searchPromptMenu;
        [SerializeField] private TextMeshProUGUI riskAmount;
        [SerializeField] private TextMeshProUGUI rewardAmount;
        [SerializeField] private TextMeshProUGUI resultText;
        [SerializeField] private TextMeshProUGUI chanceAmount;

        private GameManager gameManager;
        private PlayerHandler playerHandler;
        private ShakeCamera camShake;

        private AudioManager audioManager;

        private void Start() {
            audioManager = FindObjectOfType<AudioManager>();
            gameManager = FindObjectOfType<GameManager>();
            camShake = FindObjectOfType<ShakeCamera>();
            
            searchPromptMenu.SetActive(false);
            resultText.text = "";
        }

        private void Update() {
            if (!playerHandler) return;

            if (Input.GetKeyDown(KeyCode.E) && playerHandler.GetComponent<PlayerMovement>().enabled) {
                GameManager.IsMenuOpen = !GameManager.IsMenuOpen;
                searchPromptMenu.SetActive(GameManager.IsMenuOpen);
                searchPromptText.SetActive(false);
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            riskAmount.text = loseTurns.ToString();
            rewardAmount.text = itemType.itemName;
            chanceAmount.text = chanceOfGettingItems.ToString();

            if (other.GetComponent<PlayerMovement>().enabled) {
                searchPromptText.SetActive(true);
                playerHandler = other.GetComponent<PlayerHandler>();
            }
            else {
                playerHandler = null;
            }
        }

        private void OnTriggerStay(Collider other) {
            if (!other.GetComponent<PlayerMovement>().enabled)
                playerHandler = null;
            else
                playerHandler = other.GetComponent<PlayerHandler>();
        }

        private void OnTriggerExit2D(Collider2D other) {
            playerHandler = null;
            GameManager.IsMenuOpen = false;
            searchPromptMenu.SetActive(false);
            searchPromptText.SetActive(false);
            resultText.text = "";
        }

        public void RandomizeItemChance() {
            if (!playerHandler) return;
            
            int chanceRolled = Random.Range(0, 100);
            camShake.Shake();
            
            if (chanceRolled < chanceOfGettingItems) {
                GiveItems();
                resultText.text = "+1 " + itemType.itemName;
            }
            else {
                audioManager.Play("HungerLoss");
                gameManager.ReduceTurns(loseTurns);
                resultText.text = "-" + loseTurns + " HP";
            }
        }

        public void Back() {
            GameManager.IsMenuOpen = false;
            searchPromptMenu.SetActive(false);
            searchPromptText.SetActive(false);
            resultText.text = "";
        }        

        private void GiveItems() {
            audioManager.Play("Pickup");
            playerHandler.AddItems(itemType);
        } 
    }
}