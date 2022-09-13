using UnityEngine;

namespace OTU.Core {
    public class NumberOfRolls : MonoBehaviour
    {
        public int maxTurnsAllowed = 30;

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
    }
}