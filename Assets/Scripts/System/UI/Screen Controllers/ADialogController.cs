using UnityEngine;

namespace LSW.UI
{
    public abstract class ADialogController : MonoBehaviour, IDialogController
    {
        public string screenID { get; set; }
        public bool isVisible { get; set; }

        public virtual void Show()
        {
            if (!gameObject.activeSelf)
            {
                gameObject.SetActive(true);
                gameObject.transform.SetAsLastSibling();
                isVisible = true;
            }
        }

        /// <summary>
        /// ATTENTION: Don't call this function inside a dialog controller, make the dialog layer hide it
        /// </summary>
        public virtual void Hide()
        {
            if (gameObject.activeSelf)
            {
                gameObject.SetActive(false);
                isVisible = false;
            }
        }
    }
}