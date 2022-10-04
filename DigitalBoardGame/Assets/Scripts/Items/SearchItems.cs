using UnityEngine;

namespace OTU.Items {
    public class SearchItems : MonoBehaviour 
    {
        private BuildingTrigger[] buildingTriggers;

        private void Start() {
            buildingTriggers = FindObjectsOfType<BuildingTrigger>();
        }

        public void SearchForItems() {
            foreach (BuildingTrigger trigger in buildingTriggers) {
                if (trigger.enabled) {
                    trigger.RandomizeItemChance();
                }
            }
        }           
    }
}