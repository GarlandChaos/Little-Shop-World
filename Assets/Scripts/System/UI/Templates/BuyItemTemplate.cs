using UnityEngine;
using UnityEngine.EventSystems;
using LSW.Gameplay;

namespace LSW.UI
{
    public class BuyItemTemplate : ItemTemplate
    {
        bool clickable = true;

        private void Start()
        {
            UpdateClickableStatus();
        }

        public override void InitializeItemTemplate(Item i, int id = -1)
        {
            base.InitializeItemTemplate(i, id);
            UpdateClickableStatus();
        }

        void UpdateClickableStatus()
        {
            if (FundsManager.instance != null && item != null)
            {
                if (FundsManager.instance._Funds >= item._BuyPrice)
                {
                    clickable = true;
                    image.color = new Color(1f, 1f, 1f, 1f);
                }
                else
                {
                    clickable = false;
                    image.color = new Color(1f, 1f, 1f, 0.5f);
                }
            }
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (clickable)
                eventClickedOnItemTemplate.Raise(item, inventoryId, InfoType.Buy);
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            eventShowItemDetails.Raise(item, InfoType.Buy);
        }
    }
}