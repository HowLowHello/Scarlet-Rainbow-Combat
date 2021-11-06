using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCraftInventory : MonoBehaviour
{
    [SerializeField] private List<Craft> craftsOnEquip = new List<Craft>();
    [SerializeField] private PlayerCraftInventoryUI craftInventoryUI;
    private PlayerCraftInventoryUI _playerCraftInventoryUI;

    private PlayerCraftInventoryUI playerCraftInventoryUI
    {
        get
        {
            _playerCraftInventoryUI = FindObjectOfType<PlayerCraftInventoryUI>();
            if (!_playerCraftInventoryUI)
            {
                Debug.Log("playerCraftInventoryUI not found in Scene.");
            }
            return _playerCraftInventoryUI;
        }
    }

    public List<Craft> GetCraftsOnEquip()
    {
        return craftsOnEquip;
    }

    public void InitCraftInventoryUI()
    {
        playerCraftInventoryUI.InitUI(this);
    }

    public void CloseUI()
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
