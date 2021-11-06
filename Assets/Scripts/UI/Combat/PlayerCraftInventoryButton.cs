using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerCraftInventoryButton : Button
{
    private PlayerCraftInventorySlot slot;
    private GameObject craftPoolUICanvas;

    public void SetSlot(PlayerCraftInventorySlot slotIn, GameObject craftPoolUICanvas)
    {
        this.slot = slotIn;
        this.craftPoolUICanvas = craftPoolUICanvas;
    }


    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        if (!craftPoolUICanvas.activeInHierarchy)
        {
            return;
        }
        GameObject gameMaster = GameObject.Find("Game Master");
        if (gameMaster)
        {
            CraftEquipmentController equipmentController = gameMaster.GetComponent<CraftEquipmentController>();
            if (equipmentController)
            {
                DraggableIcon iconBeingDragged = equipmentController.GetIconBeingDragged();
                if (iconBeingDragged)
                {
                    slot.AssignCraft(iconBeingDragged.craft);
                    slot.InitSlotVisualization(iconBeingDragged.craft.GetSprite());
                }
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
