using UnityEngine;
using OTU.Managers;

namespace OTU.UI {
    public class PlayerUsernames : MonoBehaviour
    {
        private PlayerHandler[] players;

        private string username1;
        private string username2;
        private string username3;
        private string username4;

        private void Start() {
            players = FindObjectsOfType<PlayerHandler>();
        }

        public void SetPlayerName1(string name) {
            username1 = name;
            SetUsernames();
        }

        public void SetPlayerName2(string name) {
            username2 = name;
            SetUsernames();
        }

        public void SetPlayerName3(string name) {
            username3 = name;
            SetUsernames();
        }

        public void SetPlayerName4(string name) {
            username4 = name;
            SetUsernames();
        }

        private void SetUsernames() {
            foreach (PlayerHandler player in players) {
                if (player.playerNumber == PlayerHandler.PlayerNumber.player1) {
                    player.name = username1;
                }
                else if (player.playerNumber == PlayerHandler.PlayerNumber.player2) {
                    player.name = username2;
                }
                else if (player.playerNumber == PlayerHandler.PlayerNumber.player3) {
                    player.name = username3;
                }
                else if (player.playerNumber == PlayerHandler.PlayerNumber.player4) {
                    player.name = username4;
                }
                else {
                    Debug.LogError("No players found!");
                    return;
                }
            }
        }
    }
}