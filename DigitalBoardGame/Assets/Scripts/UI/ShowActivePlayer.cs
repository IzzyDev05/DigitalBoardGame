using UnityEngine;
using TMPro;
using OTU.Managers;

namespace OTU.UI {
    public class ShowActivePlayer : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI activePlayerNumber;
        private SwitchPlayers switchPlayers;

        private void Start() {
            switchPlayers = FindObjectOfType<SwitchPlayers>();
        }

        private void Update() {
            activePlayerNumber.text = switchPlayers.GetActivePlayerName();
        }
    }
}