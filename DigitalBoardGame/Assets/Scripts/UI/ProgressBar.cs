using UnityEngine;
using UnityEngine.UI;
using OTU.Core;

namespace OTU.UI {
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] Image mask;

        private GameManager gameManager;
        private int maximum;
        private int current;

        private void Start() {
            gameManager = FindObjectOfType<GameManager>();
            maximum = gameManager.GetMaxTurns();
        }

        private void Update() {
            GetCurrentFill();
        }

        private void GetCurrentFill() {
            current = gameManager.GetTurnsRolled();
            float fillAmount = (float)current / (float)maximum;

            if (fillAmount <= 0) {
                fillAmount = 0;
            }

            float removeFromFill = 1 - fillAmount;
            mask.fillAmount = removeFromFill;
        }
    }
}