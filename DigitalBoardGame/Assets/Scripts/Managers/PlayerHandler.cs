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
        private int totalItems = 0;

        public void AddItem(int numberOfItems) {
            totalItems += numberOfItems;
        }

        public void RemoveItems() {
            totalItems = 0;
        }

        public int GetTotalItems() {
            return totalItems;
        }
    }
}