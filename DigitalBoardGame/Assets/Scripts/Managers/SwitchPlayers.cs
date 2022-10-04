using UnityEngine;
using OTU.Movement;
using OTU.Core;

namespace OTU.Managers {
    public class SwitchPlayers : MonoBehaviour {
        [SerializeField] private GameObject[] players;

        private GameManager gameManager;
        private GameObject[] interfaces;
        private GameObject activePlayerObject;

        private void Start() {
            gameManager = GetComponent<GameManager>();
            interfaces = gameManager.interfaces;

            ReturnPlayerMovement(players[0]).enabled = true;
            ReturnPlayerMovement(players[1]).enabled = false;
            ReturnPlayerMovement(players[2]).enabled = false;
            ReturnPlayerMovement(players[3]).enabled = false;

            activePlayerObject = players[0];
        }

        private void Update() {
            CastRay();
        }

        private void CastRay() {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

            if (hit.collider != null) {
                if (hit.collider.CompareTag("Player") && Input.GetMouseButtonDown(0)) {
                    SwitchBetweenPlayers(hit);

                    foreach (GameObject obj in interfaces) {
                        obj.SetActive(false);
                    }
                }
            }
        }

        private void SwitchBetweenPlayers(RaycastHit2D hit) {
            PlayerHandler player = hit.collider.GetComponent<PlayerHandler>();

            if (player.playerNumber == PlayerHandler.PlayerNumber.player1) {
                SetPlayers(players[0], players[1], players[2], players[3]);
                activePlayerObject = players[0];
            }
            if (player.playerNumber == PlayerHandler.PlayerNumber.player2) {
                SetPlayers(players[1], players[0], players[2], players[3]);
                activePlayerObject = players[1];
            }
            if (player.playerNumber == PlayerHandler.PlayerNumber.player3) {
                SetPlayers(players[2], players[0], players[1], players[3]);
                activePlayerObject = players[2];
            }
            if (player.playerNumber == PlayerHandler.PlayerNumber.player4) {
                SetPlayers(players[3], players[0], players[1], players[2]);
                activePlayerObject = players[3];
            }
        }

        private void SetPlayers(GameObject toEnable, GameObject disable1, GameObject disable2, GameObject disable3) {
            toEnable.GetComponent<PlayerMovement>().EnablePlayerMovement();
            
            ReturnPlayerMovement(toEnable).enabled = true;
            ReturnPlayerMovement(disable1).enabled = false;
            ReturnPlayerMovement(disable2).enabled = false;
            ReturnPlayerMovement(disable3).enabled = false;
        }

        private PlayerMovement ReturnPlayerMovement(GameObject player) {
            return player.GetComponent<PlayerMovement>();
        }

        public string GetActivePlayerName() {
            return activePlayerObject.name;
        }
    }
}