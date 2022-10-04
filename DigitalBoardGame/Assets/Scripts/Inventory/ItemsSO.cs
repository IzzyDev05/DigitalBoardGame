using UnityEngine;

namespace OTU.Inventory {
    [CreateAssetMenu(fileName = "New Item", menuName = "New Item")]
    public class ItemsSO : ScriptableObject 
    {
        public enum ItemType {
            screws,
            fuel,
            wood,
            rubber
        }

        public string itemName;
        public ItemType itemType;
    }
}