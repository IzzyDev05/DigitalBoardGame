using UnityEngine;
using OTU.Core;
using TMPro;

namespace OTU.UI {
    public class PlayedTime : MonoBehaviour 
    {
        [SerializeField] TextMeshProUGUI[] timePlayedText;

        private GameManager gameManager;
        private float playedTime;

        private void Start() {
            gameManager = FindObjectOfType<GameManager>();
        }

        private void Update() {
            if (!GameManager.HasGameEnded) {
                playedTime = gameManager.GetPlayedTime();
            }
            
            foreach (TextMeshProUGUI time in timePlayedText) {
                time.text = Mathf.RoundToInt(playedTime).ToString();
            }
        }
    }
}