using UnityEngine;

namespace OTU.UI {
    [CreateAssetMenu(fileName = "Dialogue", menuName = "New Dialogue")]
    public class DialogueSO : ScriptableObject 
    {
        [TextArea(20, 40)] public string dialogueText;
        public int dialougeNumber;
        public bool isFinalDialogue;
    }
}