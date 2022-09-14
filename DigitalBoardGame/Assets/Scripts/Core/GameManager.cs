using System;
using UnityEngine;

namespace OTU.Core {
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private int maxTurnsAllowed = 30;

        public bool GameOver(int turnsRolled) {
            if (turnsRolled > maxTurnsAllowed) {
                print("Game over!");
                return true;
            }
            return false;
        }

        public void ReduceTurns(int reduce) {
            maxTurnsAllowed -= reduce;
        }

        public int GetMaxTurns() {
            return maxTurnsAllowed;
        }
    }
}