using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCraftInventoryUI : UIHasSlots
{
    private Dictionary<int, PlayerCraftInventorySlot> indexToSlotMap = new Dictionary<int, PlayerCraftInventorySlot>();

    public void InitUI(PlayerCraftInventory inventory)
    {
        var craftList = inventory.GetCraftsOnEquip();
        for (int slotIndex = 0; slotIndex < 4; slotIndex++)
        {
            if (craftList[slotIndex] != null)
            {
                PlayerCraftInventorySlot slot = CreateSlot(inventory, craftList[slotIndex], slotIndex);
                if (slot)
                {
                    indexToSlotMap.Add(slotIndex, slot);
                }
            }
            else
            {
                PlayerCraftInventorySlot slot = CreateSlot(slotIndex);
                if (slot)
                {
                    indexToSlotMap.Add(slotIndex, slot);
                }
            }
        }
    }

    public void AssignCraftToSpecificSlot(Craft newCraft, int slotIndex) 
    {
        PlayerCraftInventorySlot slot = indexToSlotMap[slotIndex];
        if (slot == null)
        {
            Debug.LogError("Slot not found.");
            return;
        }
        slot.AssignCraft(newCraft);
        slot.InitSlotVisualization(newCraft.GetSprite());
    }

    public void UpdateUI(PlayerCraftInventory inventory)
    {
        var craftList = inventory.GetCraftsOnEquip();
        for (int slotIndex = 0; slotIndex < 4; slotIndex++)
        {
            PlayerCraftInventorySlot slot = indexToSlotMap[slotIndex];
            if (slot == null)
            {
                Debug.LogError("Slot not found.");
                return;
            }
            if (craftList[slotIndex] == null)
            {
                slot.AssignCraft(null);
                slot.InitSlotVisualization(null);
            }
            else
            {
                slot.AssignCraft(craftList[slotIndex]);
                slot.InitSlotVisualization(craftList[slotIndex].GetSprite());
            }
        }
    }

    private PlayerCraftInventorySlot CreateSlot(int slotIndex)
    {
        var slot = Instantiate(slotPrefab, slotsParent);
        if (slot is PlayerCraftInventorySlot)
        {
            PlayerCraftInventorySlot craftSlot = (PlayerCraftInventorySlot)slot;
            craftSlot.SetSlotIndex(slotIndex);
            craftSlot.InitButton();
            craftSlot.AssignSlotButtonCallback(() => craftSlot.PerformCraftInCombat());
            return craftSlot;
        }
        else
        {
            Debug.LogError("Wrong Craft Slot Prefab.");
            return null;
        }
    }

    protected PlayerCraftInventorySlot CreateSlot(PlayerCraftInventory inventory, Craft craft, int index)
    {
        var slot = Instantiate(slotPrefab, slotsParent);
        if (slot is PlayerCraftInventorySlot)
        {
            PlayerCraftInventorySlot craftSlot = (PlayerCraftInventorySlot)slot;
            craftSlot.SetSlotIndex(index);
            craftSlot.InitButton();
            craftSlot.AssignCraft(craft);
            craftSlot.InitSlotVisualization(craft.GetSprite());
            craftSlot.AssignSlotButtonCallback(() => craftSlot.PerformCraftInCombat());
            return craftSlot;
        }
        else
        {
            Debug.LogError("Wrong Craft Slot Prefab.");
            return null;
        }
    }




    public override void InitUI()
    {
        throw new System.NotImplementedException();
    }

    protected override void CreateSlot()
    {
        throw new System.NotImplementedException();
    }

}
