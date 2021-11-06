using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftEquipmentController : MonoBehaviour
{
    [SerializeField] private CraftPool craftPool;
    [SerializeField] private PlayerCraftInventory playerCraftInventory;
    [SerializeField] private Transform craftPoolUIParent;
    [SerializeField] private GameObject draggableIconPrefab;
    private GameObject instantiatedIcon;

    public void InstantiateDraggableCraftIcon(Craft craft, CraftPoolButton fromButton)
    {
        GameObject iconObject = Instantiate<GameObject>(draggableIconPrefab, craftPoolUIParent);
        this.instantiatedIcon = iconObject;
        DraggableIcon icon = iconObject.GetComponent<DraggableIcon>();
        if (icon)
        {
            icon.Init(craft, fromButton);
        }
        else
        {
            Debug.LogError("DraggableIcon Script is not correct");
            return;
        }
          

    }

    public DraggableIcon GetIconBeingDragged()
    {
        if (instantiatedIcon == null)
        {
            return null;
        }
        DraggableIcon draggableIcon = instantiatedIcon.GetComponent<DraggableIcon>();
        return draggableIcon;
    }

    public void OnIconDraggingFinished()
    {
        if (instantiatedIcon == null)
        {
            return;
        }
    }


    private void Start()
    {
        craftPool.InitPool(this);
        craftPool.OpenUI();
        playerCraftInventory.InitCraftInventoryUI();
    }

    public Transform GetUIParent()
    {
        return craftPoolUIParent;
    }
}
