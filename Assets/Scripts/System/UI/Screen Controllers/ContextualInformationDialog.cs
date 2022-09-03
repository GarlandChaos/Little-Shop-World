using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace LSW.UI
{
    public class ContextualInformationDialog : ASpecialController
    {
        [SerializeField]
        TMP_Text textItemName = null;
        [SerializeField]
        TMP_Text textItemDescription = null;
        [SerializeField]
        TMP_Text textPrice = null;
        [SerializeField]
        RectTransform rectTransform = null;
        float mouseOffset = 30f;

        private void OnEnable()
        {
            textPrice.enabled = false;
        }

        private void Update()
        {
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                Vector2 movePos = Vector2.zero;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    UIManager.instance._MainCanvas.transform as RectTransform,
                    Input.mousePosition, UIManager.instance._UICamera,
                    out movePos);
                movePos.x += rectTransform.rect.width / 2 + mouseOffset;
                movePos.y -= rectTransform.rect.height / 2 + mouseOffset;
                rectTransform.anchoredPosition = movePos;
            }
        }

        public void ShowItemDetails(Item item, InfoType infoType)
        {
            textItemName.text = item._Name;
            textItemDescription.text = item._Description;
            if (infoType != InfoType.Simple)
            {
                textPrice.text = (infoType == InfoType.Buy) ? "Buy for: " + item._BuyPrice.ToString() : "Sell for: " + item._SellPrice.ToString();
                textPrice.enabled = true;
            }

            LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);

            //Set fake mouse Cursor
            //mouseCursor.transform.position = mousePos;
        }
    }
}