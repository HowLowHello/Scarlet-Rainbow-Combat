using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CraftPoolButton : Button
{
    private CraftPoolSlot slot;

    public bool IsButtonDown()
    {
        return IsPressed();
    }

    public void SetSlot(CraftPoolSlot slot)
    {
        this.slot = slot;
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        if (!IsPressed())
        {
            return;
        }
        else
        {
            GameObject gameMaster = GameObject.Find("Game Master");
            if (gameMaster)
            {
                CraftEquipmentController equipmentController = gameMaster.GetComponent<CraftEquipmentController>();
                if (equipmentController)
                {
                    equipmentController.InstantiateDraggableCraftIcon(slot.craft, this);
                }
                else
                {
                    Debug.LogError("CraftEquipmentController is not correct");
                }
            }
            else
            {
                Debug.LogError("Game Master not found or has changed name");
            }
        }

    }
}
