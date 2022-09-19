using UnityEngine;
using TMPro;
using OTU.Managers;

namespace OTU.UI {
    public class ShowActivePlayer : MonoBehaviour {
        [SerializeField] private SwitchPlayers gameManager;
        [SerializeField] private TextMeshProUGUI activePlayerNumber;

        private void Update() {
            activePlayerNumber.text = gameManager.GetActivePlayerName();
        }
    }
}