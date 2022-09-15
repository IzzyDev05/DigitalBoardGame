using UnityEngine;
using TMPro;
using OTU.Managers;

namespace OTU.UI {
    public class ShowActivePlayer : MonoBehaviour {
        [SerializeField] SwitchPlayers gameManager;
        [SerializeField] TextMeshProUGUI activePlayerNumber;

        private void Update() {
            activePlayerNumber.text = gameManager.GetActivePlayerName();
        }
    }
}