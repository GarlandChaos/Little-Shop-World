using UnityEngine;

namespace LSW.UI
{
    public class CursorController : MonoBehaviour
    {
        [SerializeField]
        Texture2D textureCursorDefault = null;
        [SerializeField]
        Texture2D textureCursorInteractable = null;
        [SerializeField]
        Texture2D textureCursorNotInteractable = null;
        Texture2D textureCurrent = null;

        private void Start()
        {
            textureCurrent = textureCursorDefault;
        }

        void ChangeCursorTexture(Texture2D texture)
        {
            if (texture != textureCurrent)
            {
                Cursor.SetCursor(texture, Vector2.zero, CursorMode.Auto);
                textureCurrent = texture;
            }
        }
        public void ChangeCursorToInteractable()
        {
            ChangeCursorTexture(textureCursorInteractable);
        }

        public void ChangeCursorToNotInteractable()
        {
            ChangeCursorTexture(textureCursorNotInteractable);
        }

        public void ChangeCursorToDefault()
        {
            ChangeCursorTexture(textureCursorDefault);
        }
    }
}