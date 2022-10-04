using UnityEngine;
using OTU.Core;
using OTU.UI;

namespace OTU.Movement {
public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private DieRoller dieRoller;
        [Range(0, 1)] [SerializeField] private float movementFactor = 1;
        [SerializeField] private float raycastDistance = 10f;
        [SerializeField] private LayerMask edgeLayer;

        private AudioManager audioManager;
        private int spacesToMove = 0;
        private bool shouldMove = false;
        private bool canMove = true;
        private Vector3 lastPos;

        private AudioRandomization audioRandomization;

        private void Start() {
            audioRandomization = FindObjectOfType<AudioRandomization>();
        }

        private void Update() {
            if (shouldMove) {
                MovePlayer();
            }
        }

        public void RollDie(int rolledSpaces) {
            lastPos = transform.position;

            spacesToMove = rolledSpaces;
            gameManager.IncreaseTurnsRolled();
            bool isOver = gameManager.GetComponent<GameManager>().GameOver();

            if (isOver) return;
            shouldMove = true;
        }
        
        private void MovePlayer() {
            if (Input.GetKeyDown(KeyCode.W)) {
                MovePlayerInDirection(Vector2.up);
            }
            if (Input.GetKeyDown(KeyCode.A)) {
                MovePlayerInDirection(Vector2.left);
            }
            if (Input.GetKeyDown(KeyCode.S)) {
                MovePlayerInDirection(Vector2.down);
            }
            if (Input.GetKeyDown(KeyCode.D)) {
                MovePlayerInDirection(Vector2.right);
            }            
        }

        private void MovePlayerInDirection(Vector2 direction) {
            CheckBoundry(direction);

            if (spacesToMove > 0) {
                if (!canMove) return;

                transform.Translate(direction * movementFactor);
                audioRandomization.RandomizeFootsteps();
                canMove = false;
                CheckBoundry(direction);

                spacesToMove--;
            }
            else {
                shouldMove = false;
            }
        }

        private void CheckBoundry(Vector2 direction) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, raycastDistance, edgeLayer);

            if (hit.collider != null) {
                canMove = false;
            }
            else {
                canMove = true;
            }
        }

        // This is called when we are changing the player so that the this player's canMove does not transfer to the other players
        public void EnablePlayerMovement() {
            canMove = true;
        }
    }
}