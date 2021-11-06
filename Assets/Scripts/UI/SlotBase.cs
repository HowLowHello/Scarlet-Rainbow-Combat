using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SlotBase : MonoBehaviour
{
    [SerializeField] protected Image image;
    [SerializeField] protected Button slotButton;
    private int slotIndex;

    public void SetSlotIndex(int index)
    {
        this.slotIndex = index;
    }

    public int GetSlotIndex()
    {
        return slotIndex;
    }

    public abstract void InitSlotVisualization(Sprite sprite);

    public abstract void AssignSlotButtonCallback(System.Action onClickCallback);
}
