using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Craft System/Craft Pool")]
public class CraftPool : Inventory
{
    [SerializeField] private List<CraftWrapper> craftWrappers = new List<CraftWrapper>();
    [SerializeField] private CraftPoolUI craftPoolUIPrefab;
    [SerializeField] private List<Craft> crafts = new List<Craft>();
    private CraftEquipmentController equipmentController;
    private CraftPoolUI _craftPoolUI;

    private CraftPoolUI craftPoolUI
    {
        get
        {
            _craftPoolUI = FindObjectOfType<CraftPoolUI>();
            if (!_craftPoolUI)
            {
                Debug.Log("Craft Pool UI not found in Scene.");
                _craftPoolUI = Instantiate(craftPoolUIPrefab, equipmentController.GetUIParent());
            }
            return _craftPoolUI;
        }
    }

    public List<Craft> GetAllCrafts()
    {
        return crafts;
    }

    public void InitPool(CraftEquipmentController equipmentController)
    {
        for (int i = 0; i < craftWrappers.Count; i++)
        {
            crafts.Add(craftWrappers[i].craft);
        }
        this.equipmentController = equipmentController;
    }


    public override void OpenUI()
    {
        craftPoolUI.gameObject.SetActive(true);
        craftPoolUI.InitUI(this);
    }

    public override void CloseUI()
    {
        throw new System.NotImplementedException();
    }

    public void AssignCraft(Craft craft)
    {
        Debug.Log(string.Format("Craft Assigned", craft.getName()));
    }


}
