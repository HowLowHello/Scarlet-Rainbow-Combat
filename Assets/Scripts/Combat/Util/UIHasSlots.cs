using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIHasSlots : MonoBehaviour
{
    [SerializeField] protected Transform slotsParent;
    [SerializeField] protected SlotBase slotPrefab;

    public abstract void InitUI();

    protected abstract void CreateSlot();
}
