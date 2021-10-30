using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCraftInventorySlot : SlotBase
{
    [SerializeField] private Craft craft;

    public Craft GetCraft()
    {
        return craft;
    }

    public void AssignCraft(Craft craft)
    {
        this.craft = craft;
    }

    public override void AssignSlotButtonCallback(Action onClickCallback)
    {
        throw new NotImplementedException();
    }

    public override void InitSlotVisualization(Sprite sprite)
    {
        image.sprite = sprite;
    }


    public void PerformCraftInCombat()
    {
        if (craft)
        {
            craft.PerformCraftInCombat();
        }
        else
        {
            Debug.Log("No Craft Assigned");
        }

    }

}
