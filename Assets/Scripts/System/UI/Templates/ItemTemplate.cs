using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemTemplate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] //remove the attribute in the end
    Item item = null;
    [SerializeField]
    Image image = null;

    public Item _Item { get => item; }

    public void FillItem(Item i)
    {
        item = i;
        image.sprite = i._Sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(item._Description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //remove description;
    }
}
