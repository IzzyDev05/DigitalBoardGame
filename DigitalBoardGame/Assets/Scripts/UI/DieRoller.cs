using UnityEngine;
using TMPro;
using OTU.Core;
using OTU.Movement;

namespace OTU.UI {
    public class DieRoller : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI rolledNumber;
        [SerializeField] TextMeshProUGUI rollsLeft;
        [SerializeField] GameManager gameManager;
        [SerializeField] PlayerMovement[] players;

        private int spacesToMove;
        private int turnsRolled;

        private void Start() {
            rollsLeft.text = gameManager.GetMaxTurns().ToString();
        }
        
        private void Update() {
            turnsRolled = players[0].GetTurnsRolled();

            int turnsLeft = gameManager.GetMaxTurns() - turnsRolled;
            rollsLeft.text = turnsLeft.ToString();
        }

        public void RollDie() {
            spacesToMove = Random.Range(1, 7);
            rolledNumber.text = spacesToMove.ToString();

            foreach(PlayerMovement player in players) {
                player.RollDie(spacesToMove);
            }
        }

        public int GetDieRoll() {
            return spacesToMove;
        }
    }
}