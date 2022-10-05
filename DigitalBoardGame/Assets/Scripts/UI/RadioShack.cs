using UnityEngine;
using UnityEngine.UI;
using OTU.Core;
using OTU.Managers;
using OTU.Movement;
using TMPro;

namespace OTU.UI {
    public class RadioShack : MonoBehaviour
    {
        [SerializeField] private GameObject callPrompt;
        [SerializeField] private GameObject callAlert;
        [SerializeField] private GameObject callContentMenu;
        [SerializeField] private TextMeshProUGUI callContentText;
        [SerializeField] private DialogueSO[] dialogues;
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI buttonText;

        private int currentDialogue = 0;
        private bool hasFinalDialogueBeenChecked = false;
        private bool hasDialougeRun;
        private PlayerHandler player = null;
        private AudioManager audioManager;

        private void Start() {
            audioManager = FindObjectOfType<AudioManager>();

            callContentText.text = dialogues[0].dialogueText;

            callContentMenu.SetActive(false);
            callPrompt.SetActive(false);
            callAlert.SetActive(true);
        }

        private void Update() {
            if (player == null || hasDialougeRun) {
                callPrompt.SetActive(false);
                callContentMenu.SetActive(false);
                return;
            }

            if (Input.GetKeyDown(KeyCode.E)) {
                GameManager.IsMenuOpen = !GameManager.IsMenuOpen;

                callPrompt.SetActive(false);
                callContentMenu.SetActive(GameManager.IsMenuOpen);
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.GetComponent<PlayerMovement>().enabled) {
                callPrompt.SetActive(true);
                player = other.GetComponent<PlayerHandler>();
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            callPrompt.SetActive(false);
            player = null;
        }

        public void Next() {
            audioManager.Play("Click");

            if (!hasFinalDialogueBeenChecked && dialogues[currentDialogue + 1].isFinalDialogue) {
                hasFinalDialogueBeenChecked = true;
                buttonText.text = "End call";
                button.onClick.AddListener(EndDialogue);
            }

            if (!dialogues[currentDialogue].isFinalDialogue) {
                callContentText.text = dialogues[currentDialogue + 1].dialogueText;
                currentDialogue = dialogues[currentDialogue + 1].dialougeNumber;
            }
        }

        public void Back() {
            GameManager.IsMenuOpen = false;
            callContentMenu.SetActive(false);
        }

        private void EndDialogue() {
            GameManager.IsMenuOpen = false;
            hasDialougeRun = true;
            callAlert.SetActive(false);
        }
    }
}