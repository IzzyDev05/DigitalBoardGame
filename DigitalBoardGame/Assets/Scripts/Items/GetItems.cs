using UnityEngine;
using OTU.Core;

namespace RPG.Items {
    public class GetItems : MonoBehaviour 
    {
        [SerializeField] GameObject gameManager;
        [Range(0,100)][SerializeField] private int chanceOfGettingItems = 50;
        [SerializeField] private int loseTurns = 2;

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                CheckForItems();
            }
        }

        private void CheckForItems() {
            int chanceRolled = Random.Range(0, 100);

            if (chanceRolled < chanceOfGettingItems) {
                gameManager.GetComponent<NumberOfRolls>().ReduceTurns(loseTurns);
            }
            else {
                print("Great, you found 3 items!");
            }
        }
    }
}