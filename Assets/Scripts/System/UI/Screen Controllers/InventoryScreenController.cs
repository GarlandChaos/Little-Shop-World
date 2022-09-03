using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace LSW.UI
{
    public class InventoryScreenController : APanelController
    {
        protected List<ItemTemplate> itemTemplates = new List<ItemTemplate>();
        [SerializeField]
        protected RectTransform itemContainer = null;
        [SerializeField]
        protected ItemTemplate itemTemplatePrefab = null;
        [SerializeField]
        protected TMP_Text textFunds = null;
        [SerializeField]
        protected Inventory inventory = null;

        private void OnEnable()
        {
            RefreshScreen();
        }

        public void AddItemTemplate(Item item, int index)
        {
            if(index < itemTemplates.Count)
            {
                itemTemplates[index].InitializeItemTemplate(item, inventory._Id);
            }
            else
            {
                ItemTemplate template = Instantiate(itemTemplatePrefab, itemContainer, false);
                template.InitializeItemTemplate(item, inventory._Id);
                itemTemplates.Add(template);
            }
        }

        public virtual void RefreshScreen()
        {
            inventory = InventoryManager.instance._InventoryPlayer;
            UpdateItemTemplates();
            UpdateTextFunds();
        }

        protected void UpdateItemTemplates()
        {
            ClearItemTemplates();

            if(inventory != null)
            {
                int i = 0;
                foreach (Item item in inventory.itemsList)
                {
                    AddItemTemplate(item, i);
                    i++;
                }
            }
        }

        protected void UpdateTextFunds()
        {
            if (FundsManager.instance != null)
                textFunds.text = "$" + FundsManager.instance._Funds.ToString();
        }

        public void ClearItemTemplates()
        {
            foreach(ItemTemplate template in itemTemplates)
                template.InitializeItemTemplate(null);
        }

        public void CloseScreen()
        {
            Hide();
        }
    }
}