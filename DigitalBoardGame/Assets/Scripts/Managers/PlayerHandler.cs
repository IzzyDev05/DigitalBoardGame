using UnityEngine;

namespace OTU.Managers {
    public class PlayerHandler : MonoBehaviour {
        public enum PlayerNumber {
            player1,
            player2,
            player3,
            player4
        }

        public PlayerNumber playerNumber;
    }
}