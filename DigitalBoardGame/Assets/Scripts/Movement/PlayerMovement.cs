using UnityEngine;
using OTU.Core;

namespace OTU.Movement {
public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private GameObject gameManager;

        private int spacesToMove = 0;
        private int turnsRolled = 0;
        private bool shouldMove = false;

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                RollDie();
            }
            if (shouldMove) {
                MovePlayer();
            }
        }

        private void RollDie() {
            spacesToMove = Random.Range(1, 7);
            turnsRolled++;
            bool isOver = gameManager.GetComponent<NumberOfRolls>().GameOver(turnsRolled);

            if (isOver) return;
            shouldMove = true;
        }

        private void MovePlayer() {
            Vector3 moveUp = new Vector3(0, spacesToMove, 0);
            Vector3 moveLeft = new Vector3(-spacesToMove, 0, 0);
            Vector3 moveDown = new Vector3(0, -spacesToMove, 0);
            Vector3 moveRight = new Vector3(spacesToMove, 0, 0);

            if (Input.GetKeyDown(KeyCode.W)) {
                transform.Translate(moveUp);
                shouldMove = false;
            }
            if (Input.GetKeyDown(KeyCode.A)) {
                transform.Translate(moveLeft);
                shouldMove = false;
            }
            if (Input.GetKeyDown(KeyCode.S)) {
                transform.Translate(moveDown);
                shouldMove = false;
            }
            if (Input.GetKeyDown(KeyCode.D)) {
                transform.Translate(moveRight);
                shouldMove = false;
            }            
        }
    }
}