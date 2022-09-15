using UnityEngine;
using OTU.Movement;
using OTU.Core;

namespace OTU.Managers {
    public class InitializePlayers : MonoBehaviour {
        [SerializeField] GameObject preGameUI = null;
        [SerializeField] GameObject inGameUI = null;
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

            preGameUI.SetActive(false);
            inGameUI.SetActive(true);
        }
    }
}