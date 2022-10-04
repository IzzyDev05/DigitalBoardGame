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

        [HideInInspector] public List<ItemsSO> itemsList = new List<ItemsSO>();

        public PlayerNumber playerNumber;
        private int totalItems = 0;

        public void AddItems(ItemsSO item) {
            itemsList.Add(item);
        }

        public void RemoveItems() {
            itemsList.Clear();
        }

        public int GetTotalNuts() {
            int nuts = 0;
            
            foreach (ItemsSO item in itemsList) {
                if (item.itemType == ItemsSO.ItemType.nutsAndBolts) {
                    nuts++;
                }
            }
            return nuts;
        }

        public int GetTotalFuel() {
            int fuel = 0;
            
            foreach (ItemsSO item in itemsList) {
                if (item.itemType == ItemsSO.ItemType.fuel) {
                    fuel++;
                }
            }
            return fuel;
        }

        public int GetTotalWood() {
            int wood = 0;
            
            foreach (ItemsSO item in itemsList) {
                if (item.itemType == ItemsSO.ItemType.wood) {
                    wood++;
                }
            }
            return wood;
        }
    }
}