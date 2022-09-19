using UnityEngine;

namespace OTU.Managers {
    public class InitializePlayers : MonoBehaviour {
        [HideInInspector] public bool arePlayersNamed = false;

        [SerializeField] private GameObject preGameUI = null;
        [SerializeField] private GameObject inGameUI = null;

        private PlayerHandler[] players;

        private void Start() {
            players = FindObjectsOfType<PlayerHandler>();

            preGameUI.SetActive(true);
            inGameUI.SetActive(false);

            foreach (PlayerHandler player in players) {
                player.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        public void StartGame() {
            foreach (PlayerHandler player in players) {
                player.GetComponent<SpriteRenderer>().enabled = true;
            }

            arePlayersNamed = true;
            preGameUI.SetActive(false);
            inGameUI.SetActive(true);
        }
    }
}