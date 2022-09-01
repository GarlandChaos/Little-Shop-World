using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSW.UI
{
    public class InventoryScreenController : ADialogController
    {
        [SerializeField]
        List<ItemTemplate> itemTemplates = new List<ItemTemplate>();
        [SerializeField]
        RectTransform itemContainer = null;
        [SerializeField]
        ItemTemplate itemTemplatePrefab = null;

        //TEMPORARY
        [SerializeField]
        ItemList temporaryInventoryItemList = null;

        //TEMPORARY
        private void Start()
        {
            foreach (Item i in temporaryInventoryItemList._ItemList)
                AddItem(i);
        }

        public void AddItem(Item item)
        {
            ItemTemplate template = Instantiate(itemTemplatePrefab, itemContainer, false);
            template.FillItem(item);
            itemTemplates.Add(template);
        }

        public void RemoveItem(Item item)
        {
            foreach(ItemTemplate template in itemTemplates)
            {
                if (template._Item == item)
                {
                    itemTemplates.Remove(template);
                    Destroy(template);
                }
            }         
        }
    }
}