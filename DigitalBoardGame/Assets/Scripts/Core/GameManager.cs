using UnityEngine;
using UnityEngine.SceneManagement;

namespace OTU.Core {
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private int maxTurnsAllowed = 30;

        [Header("UI")]
        [SerializeField] private GameObject inGameUI;
        [SerializeField] private GameObject gameWonScreen;
        [SerializeField] private GameObject gameLostScreen;

        private int turnsRolled;

        private void Start() {
            gameWonScreen.SetActive(false);
            gameLostScreen.SetActive(false);
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        public void GameWon() {
            inGameUI.SetActive(false);
            gameWonScreen.SetActive(true);
        }

        public bool GameOver() {
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

        public void IncreaseTurnsRolled() {
            turnsRolled++;
        }

        public int GetMaxTurns() {
            return maxTurnsAllowed;
        }

        public int GetTurnsRolled() {
            return turnsRolled;
        }
    }
}