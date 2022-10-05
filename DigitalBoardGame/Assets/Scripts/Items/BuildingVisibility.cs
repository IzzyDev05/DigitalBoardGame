using UnityEngine;
using OTU.Movement;

namespace OTU.Items {
    public class BuildingVisibility : MonoBehaviour 
    {
        [SerializeField] private SpriteRenderer building;
        

        private void Start() {
            building.enabled = false;
        }

        private void OnTriggerStay2D(Collider2D other) {
            if (other.GetComponent<PlayerMovement>().enabled) {
                building.enabled = true;
            }
        }
    }
}