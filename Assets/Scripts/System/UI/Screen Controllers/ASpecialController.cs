using UnityEngine;

namespace LSW.UI
{
    public class ASpecialController : MonoBehaviour, ISpecialController
    {
        public string screenID { get; set; }
        public bool isVisible { get; set; }

        public virtual void Show()
        {
            if (!gameObject.activeSelf)
            {
                gameObject.SetActive(true);
                isVisible = true;
            }
        }

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
