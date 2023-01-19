using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    /*[SerializeField] private InventoryPage inventoryUI;
    [SerializeField] private InventorySO inventoryData;
    private PlayerController _pc;


    private void Start()
    {
        PrepareUI();
        //inventoryData.Initialize();
        _pc = GetComponent<PlayerController>();
    }

    private void PrepareUI()
    {
        inventoryUI.InitializeInventoryUI(inventoryData.Size);
        this.inventoryUI.OnDescriptionRequested += HandleDescriptionRequest;
        this.inventoryUI.OnItemActionRequested += HandleItemActionRequest;
    }

    private void HandleDescriptionRequest(int itemIndex)
    {
        InventoryItemSO inventoryItem = inventoryData.GetItemAt(itemIndex);
        if (inventoryItem.IsEmpty)
            return;
        ItemSO item = inventoryItem.item;
        inventoryUI.UpdateDescription(itemIndex, item.ItemImage,
            item.name, item.Description);
    }

    private void HandleItemActionRequest(int itemIndex)
    {

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(inventoryUI.isActiveAndEnabled == false)
            {
                inventoryUI.Show();
                foreach (var item in inventoryData.GetCurrentInventoryState())
                {
                    inventoryUI.UpdateData(item.Key,
                        item.Value.item.ItemImage);
                }

                _pc.menu = true;
            }
            else
            {
                inventoryUI.Hide();
                _pc.menu = false;
            }
        }
    }*/
}
