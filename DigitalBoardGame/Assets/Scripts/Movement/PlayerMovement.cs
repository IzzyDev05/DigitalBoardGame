using UnityEngine;
using OTU.Core;
using OTU.UI;

namespace OTU.Movement {
public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] Sprite[] playerSprites;
        [SerializeField] ParticleSystem[] dustParticles;
        [Range(0, 1)] public float movementFactor = 1;
        [SerializeField] private float raycastDistance = 10f;
        [SerializeField] private LayerMask edgeLayer;

        private GameManager gameManager;
        private DieRoller dieRoller;
        private AudioManager audioManager;
        private AudioRandomization audioRandomization;
        private SpriteRenderer spriteRenderer;

        private int spacesToMove = 0;
        private bool shouldMove = false;
        private bool canMove = true;
        private Vector2 direction;
    
        private void Start() {
            gameManager = FindObjectOfType<GameManager>();
            dieRoller = FindObjectOfType<DieRoller>();
            audioRandomization = FindObjectOfType<AudioRandomization>();
            spriteRenderer = GetComponent<SpriteRenderer>();

            spriteRenderer.sprite = playerSprites[0];
        }

        private void Update() {
            if (shouldMove) {
                MovePlayer();
            }
        }

        public void RollDie(int rolledSpaces) {
            spacesToMove = rolledSpaces;
            gameManager.IncreaseTurnsRolled();
            bool isOver = gameManager.GetComponent<GameManager>().GameOver();

            if (isOver) return;
            shouldMove = true;
        }
        
        private void MovePlayer() {
            if (Input.GetKeyDown(KeyCode.W)) {
                direction = Vector2.up;
                MovePlayerInDirection(direction);
            }
            if (Input.GetKeyDown(KeyCode.A)) {
                direction = Vector2.left;
                MovePlayerInDirection(direction);
            }
            if (Input.GetKeyDown(KeyCode.S)) {
                direction = Vector2.down;
                MovePlayerInDirection(direction);
            }
            if (Input.GetKeyDown(KeyCode.D)) {
                direction = Vector2.right;
                MovePlayerInDirection(direction);
            }            
        }

        private void MovePlayerInDirection(Vector2 direction) {
            CheckBoundry(direction);
            UpdateSprite(direction);
            CreateDust(direction);

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

        private void UpdateSprite(Vector2 direction) {
            if (direction == Vector2.up) {
                spriteRenderer.sprite = playerSprites[0];
            }
            else if (direction == Vector2.right) {
                spriteRenderer.sprite = playerSprites[1];
            }
            else if (direction == Vector2.down) {
                spriteRenderer.sprite = playerSprites[2];
            }
            else if (direction == Vector2.left) {
                spriteRenderer.sprite = playerSprites[3];
            }
        }

        private void CreateDust(Vector2 direction) {
            if (direction == Vector2.up) {
                dustParticles[0].Play();
            }
            else if (direction == Vector2.right) {
                dustParticles[1].Play();
            }
            else if (direction == Vector2.down) {
                dustParticles[2].Play();
            }
            else if (direction == Vector2.left) {
                dustParticles[3].Play();
            }
        }

        // This is called when we are changing the player so that the this player's canMove does not transfer to the other players
        public void EnablePlayerMovement() {
            canMove = true;
        }
    }
}