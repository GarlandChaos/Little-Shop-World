using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SellItemTemplate : ItemTemplate
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        eventClickedOnItemTemplate.Raise(item, inventoryId, InfoType.Sell);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        eventShowItemDetails.Raise(item, InfoType.Sell);
    }
}
