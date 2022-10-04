using UnityEngine;
using TMPro;
using OTU.Core;
using OTU.Managers;
using OTU.Inventory;
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

        private AudioManager audioManager;

        private void Start() {
            audioManager = FindObjectOfType<AudioManager>();
            gameManager = FindObjectOfType<GameManager>();
            
            searchPromptMenu.SetActive(false);
            resultText.text = "";
        }

        private void OnTriggerEnter2D(Collider2D other) {
            riskAmount.text = loseTurns.ToString();
            rewardAmount.text = itemType.itemName;
            chanceAmount.text = chanceOfGettingItems.ToString();

            if (other.CompareTag("Player")) {
                searchPromptText.SetActive(true);
                playerHandler = other.GetComponent<PlayerHandler>();
            }
        }

        private void Update() {
            if (playerHandler != null) {
                if (Input.GetKeyDown(KeyCode.E)) {
                    searchPromptMenu.SetActive(true);
                    searchPromptText.SetActive(false);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            playerHandler = null;
            searchPromptMenu.SetActive(false);
            searchPromptText.SetActive(false);
            resultText.text = "";
        }

        public void RandomizeItemChance() {
            int chanceRolled = Random.Range(0, 100);
            FindObjectOfType<ShakeCamera>().Shake();

            if (chanceRolled < chanceOfGettingItems) {
                GiveItems();
                resultText.text = "+1 " + itemType.itemName;
            }
            else {
                gameManager.ReduceTurns(loseTurns);
                resultText.text = "-" + loseTurns + " HP";
            }
        }

        public void Back() {
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