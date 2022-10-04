using UnityEngine;

namespace OTU.Items {
public class ActivateBuldingTrigger : MonoBehaviour
    {
        private BuildingTrigger buildingTrigger;

        private void Start() {
            buildingTrigger = GetComponent<BuildingTrigger>();
            buildingTrigger.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                buildingTrigger.enabled = true;
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