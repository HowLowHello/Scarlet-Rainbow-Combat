using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftEquipmentController : MonoBehaviour
{
    [SerializeField] private CraftPool craftPool;
    [SerializeField] private PlayerCraftInventory craftInventory;
    [SerializeField] private Transform craftPoolUIParent;
    [SerializeField] private GameObject draggableIconPrefab;
    private GameObject instantiatedIcon;

    public void InstantiateDraggableCraftIcon(Craft craft, CraftPoolButton fromButton)
    {
        GameObject iconObject = Instantiate<GameObject>(draggableIconPrefab);
        iconObject.transform.position = Input.mousePosition;
        this.instantiatedIcon = iconObject;
        DraggableIcon icon = iconObject.GetComponent<DraggableIcon>();
        if (icon)
        {
            icon.originalButton = fromButton;
            icon.craft = craft;
        }
        else
        {
            Debug.LogError("DraggableIcon Script is not correct");
            return;
        }
          

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
    }

    public Transform GetUIParent()
    {
        return craftPoolUIParent;
    }
}
