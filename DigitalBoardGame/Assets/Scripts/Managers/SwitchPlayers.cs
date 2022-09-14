using UnityEngine;
using OTU.Movement;

namespace OTU.Managers {
    public class SwitchPlayers : MonoBehaviour {
        [SerializeField] GameObject player1 = null;
        [SerializeField] GameObject player2 = null;
        [SerializeField] GameObject player3 = null;
        [SerializeField] GameObject player4 = null;
    
        private int activePlayer = 1;

        private void Start() {
            ReturnPlayerMovement(player1).enabled = true;
            ReturnPlayerMovement(player2).enabled = false;
            ReturnPlayerMovement(player3).enabled = false;
            ReturnPlayerMovement(player4).enabled = false;
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
                }
            }
        }

        private void SwitchBetweenPlayers(RaycastHit2D hit) {
            PlayerHandler player = hit.collider.GetComponent<PlayerHandler>();

            if (player.playerNumber == PlayerHandler.PlayerNumber.player1) {
                DisablePlayer(player1, player2, player3, player4);
                activePlayer = 1;
            }
            if (player.playerNumber == PlayerHandler.PlayerNumber.player2) {
                DisablePlayer(player2, player1, player3, player4);
                activePlayer = 2;
            }
            if (player.playerNumber == PlayerHandler.PlayerNumber.player3) {
                DisablePlayer(player3, player1, player2, player4);
                activePlayer = 3;
            }
            if (player.playerNumber == PlayerHandler.PlayerNumber.player4) {
                DisablePlayer(player4, player1, player2, player3);
                activePlayer = 4;
            }
        }

        private void DisablePlayer(GameObject toEnable, GameObject disable1, GameObject disable2, GameObject disable3) {
            ReturnPlayerMovement(toEnable).enabled = true;
            ReturnPlayerMovement(disable1).enabled = false;
            ReturnPlayerMovement(disable2).enabled = false;
            ReturnPlayerMovement(disable3).enabled = false;
        }

        private PlayerMovement ReturnPlayerMovement(GameObject player) {
            return player.GetComponent<PlayerMovement>();
        }

        public int GetActivePlayerNumber() {
            return activePlayer;
        }
    }
}