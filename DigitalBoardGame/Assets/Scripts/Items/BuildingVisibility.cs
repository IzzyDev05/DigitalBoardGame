using UnityEngine;

namespace OTU.Items {
    public class BuildingVisibility : MonoBehaviour 
    {
        [SerializeField] private SpriteRenderer building;

        private void Start() {
            building.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                building.enabled = true;
            }
        }
    }
}