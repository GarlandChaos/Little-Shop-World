using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using LSW.Events;
using LSW.Gameplay;

namespace LSW.UI
{
    public class ItemTemplate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        protected Item item = null;
        protected int inventoryId = -1;
        [SerializeField]
        protected Image image = null;
        [SerializeField]
        protected GameEvent eventShowItemDetails = null;
        [SerializeField]
        protected GameEvent eventHideItemDetails = null;
        [SerializeField]
        protected GameEvent eventClickedOnItemTemplate = null;

        public Item _Item { get => item; }

        public virtual void InitializeItemTemplate(Item i, int id = -1)
        {
            if (i != null)
            {
                item = i;
                image.sprite = i._Sprite;
                inventoryId = id;
                gameObject.SetActive(true);
            }
            else
            {
                item = null;
                image.sprite = null;
                inventoryId = id;
                gameObject.SetActive(false);
            }
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Equipar item");
            eventClickedOnItemTemplate.Raise(item);
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            eventShowItemDetails.Raise(item, InfoType.Simple);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            eventHideItemDetails.Raise();
        }
    }
}