using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCraftInventory : Inventory
{
    [SerializeField] private List<Craft> craftsOnEquip = new List<Craft>();
    [SerializeField] private PlayerCraftInventoryUI craftInventoryUI;
        
    public List<Craft> GetCraftsOnEquip()
    {
        return craftsOnEquip;
    }

    public override void OpenUI()
    {
        throw new System.NotImplementedException();
    }

    public override void CloseUI()
    {
        throw new System.NotImplementedException();
    }

    public void AssignCraft(Craft craft, int index)
    {
        if (index > 3 || index >= craftsOnEquip.Capacity)
        {
            Debug.Log("Craft index out of range");
            return;
        }
        else if (craftsOnEquip.Contains(craft))
        {
            return;
        }
        else if (craftsOnEquip[index] != null)
        {
            craftsOnEquip[index] = craft;
            craftInventoryUI.AssignCraftToSpecificSlot(craft, index);
        }
        else
        {
            craftsOnEquip.Add(craft);
            craftInventoryUI.AssignCraftToSpecificSlot(craft, index);
        }
    }
}
