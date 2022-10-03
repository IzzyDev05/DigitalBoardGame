using UnityEngine;
using TMPro;
using OTU.Core;
using OTU.Movement;
using OTU.Managers;

namespace OTU.UI {
    public class DieRoller : MonoBehaviour
    {
        [SerializeField] private PlayerMovement[] players;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private TextMeshProUGUI rolledNumber;
        [SerializeField] private TextMeshProUGUI rollsLeft;
        
        private AudioManager audioManager;
        private int spacesToMove;
        private int turnsRolled;

        private void Start() {
            audioManager = FindObjectOfType<AudioManager>();
            players = FindObjectsOfType<PlayerMovement>();
            rollsLeft.text = gameManager.GetMaxTurns().ToString();
        }
        
        private void Update() {
            turnsRolled = gameManager.GetTurnsRolled();

            int turnsLeft = gameManager.GetMaxTurns() - turnsRolled;
            if (turnsLeft <= 0) {
                turnsLeft = 0;
            }
            rollsLeft.text = turnsLeft.ToString();
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