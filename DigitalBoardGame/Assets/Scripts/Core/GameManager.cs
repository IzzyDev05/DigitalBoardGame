using UnityEngine;

namespace OTU.Core {
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private int maxTurnsAllowed = 30;
        [SerializeField] private GameObject inGameUI;
        [SerializeField] private GameObject gameWonScreen;
        [SerializeField] private GameObject gameLostScreen;

        private void Start() {
            gameWonScreen.SetActive(false);
            gameLostScreen.SetActive(false);
        }

        public void GameWon() {
            inGameUI.SetActive(false);
            gameWonScreen.SetActive(true);
        }

        public bool GameOver(int turnsRolled) {
            if (turnsRolled > maxTurnsAllowed) {
                inGameUI.SetActive(false);
                gameLostScreen.SetActive(true);
                return true;
            }
            return false;
        }

        public void ReduceTurns(int reduce) {
            maxTurnsAllowed -= reduce;
        }

        public int GetMaxTurns() {
            return maxTurnsAllowed;
        }
    }
}