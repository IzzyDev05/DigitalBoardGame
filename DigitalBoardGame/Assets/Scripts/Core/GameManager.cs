using UnityEngine;
using UnityEngine.SceneManagement;
using OTU.Managers;

namespace OTU.Core {
    public class GameManager : MonoBehaviour
    {
        public GameObject[] interfaces;
        [HideInInspector] public static bool HasGameEnded = false;
        [HideInInspector] public static bool IsMenuOpen = false;

        [SerializeField] private int maxTurnsAllowed = 30;
        [SerializeField] private GameObject chromaticAbberation;

        [Header("UI")]
        [SerializeField] private GameObject preGameUI;
        [SerializeField] private GameObject inGameUI;
        [SerializeField] private GameObject gameWonScreen;
        [SerializeField] private GameObject gameLostScreen;

        private int turnsRolled;
        private float playedTime;

        private void Start() {
            playedTime = 0f;
            HasGameEnded = false;
            IsMenuOpen = false;

            preGameUI.SetActive(true);
            gameWonScreen.SetActive(false);
            gameLostScreen.SetActive(false);
        }

        private void Update() {
            playedTime += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Backslash)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            if (IsMenuOpen) {
                chromaticAbberation.SetActive(true);
                GetComponent<SwitchPlayers>().enabled = false;
            }
            else {
                chromaticAbberation.SetActive(false);
                GetComponent<SwitchPlayers>().enabled = true;
            }
        }

        public void GameWon() {
            HasGameEnded = true;
            FindObjectOfType<AudioManager>().Play("GameWon");

            inGameUI.SetActive(false);
            gameWonScreen.SetActive(true);
        }

        public bool GameOver() {
            if (turnsRolled > maxTurnsAllowed) {
                HasGameEnded = true;
                FindObjectOfType<AudioManager>().Play("GameLost");
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

        public float GetPlayedTime() {
            return playedTime;
        }
    }
}