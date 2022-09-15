using UnityEngine;
using TMPro;
using OTU.Core;

namespace OTU.Items {
    public class SubmitItems : MonoBehaviour
    {
        [SerializeField] private int itemsRequired = 5;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private GetItems itemGiver = null;

        [SerializeField] private GameObject submitPrompt;
        [SerializeField] private GameObject submitText;
        [SerializeField] private GameObject submitAmount;
        [SerializeField] private TextMeshProUGUI totalItems;
        [SerializeField] private GameObject itemsLeftText;
        [SerializeField] private GameObject itemsLeftAmount;

        private int itemsRecieved = 0;

        private void Start() {
            submitPrompt.SetActive(false);
            submitText.SetActive(false);
            submitAmount.SetActive(false);
            itemsLeftText.SetActive(false);
            itemsLeftAmount.SetActive(false);
        }

        private void Update() {
            itemsRecieved = itemGiver.GetTotalItems();

            totalItems.text = itemsRecieved.ToString();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (!other.CompareTag("Player")) return;
            submitPrompt.SetActive(true);
            submitText.SetActive(true);
            submitAmount.SetActive(true);

            submitAmount.GetComponent<TextMeshProUGUI>().text = itemsRequired.ToString();
        }

        private void OnTriggerStay2D(Collider2D other) {
            if (!other.CompareTag("Player")) return;

            if (Input.GetKey(KeyCode.E)) {
                if (itemsRecieved >= itemsRequired) {
                    gameManager.GameWon();
                }
                else {
                    int itemsLeft = itemsRequired - itemsRecieved;

                    itemsLeftText.SetActive(true);
                    itemsLeftAmount.GetComponent<TextMeshProUGUI>().text = itemsLeft.ToString();
                    itemsLeftAmount.SetActive(true);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            submitPrompt.SetActive(false);
            submitText.SetActive(false);
            submitAmount.SetActive(false);
            itemsLeftText.SetActive(false);
            itemsLeftAmount.SetActive(false);
        }
    }
}