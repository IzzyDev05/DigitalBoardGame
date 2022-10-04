using UnityEngine;

namespace OTU.UI {
    public class ShakeCamera : MonoBehaviour 
    {
        [SerializeField] private Animator camAnim;

        public void Shake() {
            int rand = Random.Range(0, 3);

            if (rand == 0) {
                camAnim.SetTrigger("shake01");
            }
            else if (rand == 1) {
                camAnim.SetTrigger("shake02");
            }
            else if (rand == 2) {
                camAnim.SetTrigger("shake03");
            }
        }    
    }
}