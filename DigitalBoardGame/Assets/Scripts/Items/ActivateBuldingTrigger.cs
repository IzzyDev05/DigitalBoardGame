using UnityEngine;
using OTU.Movement;

namespace OTU.Items {
public class ActivateBuldingTrigger : MonoBehaviour
    {
        [SerializeField] private BuildingTrigger[] allBuildings;
        private BuildingTrigger buildingTrigger;

        private void Start() {
            buildingTrigger = GetComponent<BuildingTrigger>();
            buildingTrigger.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.GetComponent<PlayerMovement>().enabled) {
                buildingTrigger.enabled = true;

                foreach (BuildingTrigger building in allBuildings) {
                    if (building.name != this.gameObject.name) {
                        building.enabled = false;
                    }
                }
            }
            else {
                buildingTrigger.enabled = false;
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            buildingTrigger.enabled = false;
        }
    }
}