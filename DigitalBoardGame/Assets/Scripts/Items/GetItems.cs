using UnityEngine;
using OTU.Core;
using OTU.Managers;
using OTU.Inventory;

namespace OTU.Items {
    public class GetItems : MonoBehaviour 
    {
        [Range(0, 100)][SerializeField] private int chanceOfGettingItems = 50;
        [SerializeField] private int itemsToGive;
        [SerializeField] private ItemsSO itemType;
        [SerializeField] private int loseTurns = 2;
        
        [Space(20)]
        [SerializeField] private GameObject gameManager;
        [SerializeField] private GameObject itemsGainedPrompt;
        [SerializeField] private GameObject livesLostPrompt;

        private void Start() {
            itemsGainedPrompt.SetActive(false);
            livesLostPrompt.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                CheckForItems(other);
            }
        }

        private void CheckForItems(Collider2D other) {
            int chanceRolled = Random.Range(0, 100);

            if (chanceRolled < chanceOfGettingItems) {
                GiveItems(other);
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

        private void GiveItems(Collider2D other) {
            itemsGainedPrompt.SetActive(true);
            other.GetComponent<PlayerHandler>().AddItem(itemsToGive);
            other.GetComponent<PlayerHandler>().AddActualItem(itemType);
        }
    }
}