using UnityEngine;

namespace OTU.Inventory {
    [CreateAssetMenu(fileName = "New Item", menuName = "New Item")]
    public class ItemsSO : ScriptableObject 
    {
        public enum ItemType {
            nutsAndBolts,
            fuel,
            wood,
        }

        public string itemName;
        public string itemDescription;
        public ItemType itemType;
    }
}