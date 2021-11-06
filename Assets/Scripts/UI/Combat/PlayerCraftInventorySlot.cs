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
        slotButton.onClick.AddListener(() => onClickCallback());
    }

    public override void InitSlotVisualization(Sprite sprite)
    {
        image.sprite = sprite;
    }

    public void InitButton()
    {
        if (slotButton is PlayerCraftInventoryButton)
        {
            PlayerCraftInventoryButton craftInventoryButton = (PlayerCraftInventoryButton)slotButton;
            GameObject craftPoolUICanvas = GameObject.Find("Crafts Selecting UI");
            if (craftPoolUICanvas == null)
            {
                Debug.LogError("Crafts Selecting UI not found or renamed");
                return;
            }
            craftInventoryButton.SetSlot(this, craftPoolUICanvas);
        }
        else
        {
            Debug.LogError("Button Prefab is not correct");
        }
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
