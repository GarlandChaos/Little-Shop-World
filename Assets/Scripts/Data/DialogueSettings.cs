using UnityEngine;

namespace LSW 
{
    [CreateAssetMenu(menuName = "Game Data/Dialogue Settings", fileName = "Dialogue Settings")]
    public class DialogueSettings : ScriptableObject
    {
        [SerializeField]
        string speakerName = null;
        [SerializeField]
        [TextArea]
        string dialogue = string.Empty;
        [SerializeField]
        float textSpeed = 0.2f;

        public string _SpeakerName { get => speakerName; }
        public string _Dialogue { get => dialogue; }
        public float _TextSpeed { get => textSpeed; }
    }
}