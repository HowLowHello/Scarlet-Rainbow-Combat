using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftPoolUI : UIHasSlots
{
    private bool hasInitialized = false;

    public void InitUI(CraftPool pool)
    {
        if (hasInitialized)
        {
            return;
        }
        else
        {
            var craftList = pool.GetAllCrafts();
            foreach (var craft in craftList)
            {
                CreateSlot(pool, craft);
            }
            this.hasInitialized = true;
        }
    }

    protected void CreateSlot(CraftPool pool, Craft craft)
    {
        var slot = Instantiate(slotPrefab, slotsParent);
        if (slot is CraftPoolSlot)
        {
            CraftPoolSlot poolSlot = (CraftPoolSlot)slot;
            poolSlot.InitSlotVisualization(craft.GetSprite());
            poolSlot.InitButton();
            poolSlot.craft = craft;
        }
        else
        {
            Debug.LogError("Craft Slot Prefab is not correct.");
        }
    }


    public override void InitUI()
    {
        throw new NotImplementedException();
    }

    protected override void CreateSlot()
    {
        throw new NotImplementedException();
    }
}
