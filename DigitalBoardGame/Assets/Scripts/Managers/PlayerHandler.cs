using System.Collections.Generic;
using UnityEngine;
using OTU.Inventory;

namespace OTU.Managers {
    public class PlayerHandler : MonoBehaviour {
        public enum PlayerNumber {
            player1,
            player2,
            player3,
            player4
        }

        public List<ItemsSO> itemsList = new List<ItemsSO>();

        public PlayerNumber playerNumber;
        private int totalItems = 0;

        public void AddItem(int numberOfItems) {
            totalItems += numberOfItems;
        }

        public void RemoveItems() {
            totalItems = 0;
        }

        public void AddActualItem(ItemsSO item) {
            itemsList.Add(item);
        }

        public void RemoveActualItems() {
            itemsList.Clear();
        }

        public int GetTotalItems() {
            return totalItems;
        }

        public List<ItemsSO> GetTotalItemsX() {
            return itemsList;
        }
    }
}