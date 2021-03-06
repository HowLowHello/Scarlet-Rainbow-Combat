using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftPoolSlot : SlotBase
{
    public Craft craft;

    public override void AssignSlotButtonCallback(System.Action onClickCallback)
    {

    }

    public void InitButton()
    {
        if (slotButton is CraftPoolButton)
        {
            CraftPoolButton poolButton = (CraftPoolButton)slotButton;
            poolButton.SetSlot(this);
        }
        else
        {
            Debug.LogError("Button Prefab is not correct");
        }
    }

    public override void InitSlotVisualization(Sprite sprite)
    {
        image.sprite = sprite;
    }
}
