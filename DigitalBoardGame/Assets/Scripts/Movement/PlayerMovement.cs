using UnityEngine;
using OTU.Core;
using OTU.UI;

namespace OTU.Movement {
public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] GameManager gameManager;
        [SerializeField] private DieRoller dieRoller;

        private int spacesToMove = 0;
        private int turnsRolled = 0;
        private bool shouldMove = false;

        private void Update() {
            if (shouldMove) {
                MovePlayer();
            }
        }

        public void RollDie(int rolledSpaces) {
            spacesToMove = rolledSpaces;
            turnsRolled++;
            bool isOver = gameManager.GetComponent<GameManager>().GameOver(turnsRolled);

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

        public int GetTurnsRolled() {
            return turnsRolled;
        }
    }
}