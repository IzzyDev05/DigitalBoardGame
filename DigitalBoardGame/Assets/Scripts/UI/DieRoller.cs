using UnityEngine;
using TMPro;
using OTU.Core;
using OTU.Movement;
using OTU.Managers;

namespace OTU.UI {
    public class DieRoller : MonoBehaviour
    {
        [SerializeField] private PlayerMovement[] players;
        [SerializeField] private TextMeshProUGUI rolledNumber;

        private GameManager gameManager;
        private AudioManager audioManager;
        private int spacesToMove;

        private void Start() {
            gameManager = FindObjectOfType<GameManager>();
            audioManager = FindObjectOfType<AudioManager>();
            players = FindObjectsOfType<PlayerMovement>();
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space) && !GameManager.IsMenuOpen) {
                RollDie();
            }
        }

        public void RollDie() {
            audioManager.Play("Dice Sound");
            audioManager.Play("Click");
            bool isOver = gameManager.GetComponent<GameManager>().GameOver();
            if (isOver) return;

            spacesToMove = Random.Range(1, 7);
            rolledNumber.text = spacesToMove.ToString();

            foreach(PlayerMovement player in players) {
                if (player.name == gameManager.GetComponent<SwitchPlayers>().GetActivePlayerName()) {
                    player.RollDie(spacesToMove);
                }
            }
        }

        public int GetDieRoll() {
            return spacesToMove;
        }
    }
}