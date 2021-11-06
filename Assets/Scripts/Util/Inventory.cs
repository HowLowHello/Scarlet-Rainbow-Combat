using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory : ScriptableObject
{
    public abstract void OpenUI();

    public abstract void CloseUI();
}
