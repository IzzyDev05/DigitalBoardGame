using System.Collections.Generic;
using UnityEngine;

namespace OTU.Managers {
    public class BuildingSpawner : MonoBehaviour
    {
        [SerializeField] GameObject[] buildings;
        [SerializeField] List<Transform> spawnPoints = new List<Transform>();

        private void Start() {
            foreach (GameObject building in buildings) {
                building.GetComponent<SpriteRenderer>().enabled = false;
            }

            PlaceBuilding();
        }

        private void PlaceBuilding() {
            foreach (GameObject building in buildings) {
                int rand = Random.Range(0, spawnPoints.Count);

                building.transform.position = spawnPoints[rand].position;
                spawnPoints.Remove(spawnPoints[rand]);
            }
        }
    }
}