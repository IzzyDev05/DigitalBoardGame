using UnityEngine;
using OTU.Core;

namespace OTU.Items {
    public class GetItems : MonoBehaviour 
    {
        [SerializeField] private GameObject gameManager;
        [Range(0,100)][SerializeField] private int chanceOfGettingItems = 50;
        [SerializeField] private int itemsToGive;
        [SerializeField] private int loseTurns = 2;
        [SerializeField] private GameObject itemsGainedPrompt;
        [SerializeField] private GameObject livesLostPrompt;

        private int itemsRecieved = 0;

        private void Start() {
            itemsGainedPrompt.SetActive(false);
            livesLostPrompt.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                CheckForItems();
            }
        }

        private void CheckForItems() {
            int chanceRolled = Random.Range(0, 100);

            if (chanceRolled < chanceOfGettingItems) {
                itemsGainedPrompt.SetActive(true);
                itemsRecieved += itemsToGive;
            }
            else {
                gameManager.GetComponent<GameManager>().ReduceTurns(loseTurns);
                livesLostPrompt.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            itemsGainedPrompt.SetActive(false);
            livesLostPrompt.SetActive(false);
        }

        public int GetTotalItems() {
            return itemsRecieved;
        }
    }
}