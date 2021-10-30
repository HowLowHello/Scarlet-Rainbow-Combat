using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Craft System/New Craft")]
public class Craft : ScriptableObject
{
    [SerializeField] private Sprite craftSprite;
    [SerializeField] private string craftName;

    public Sprite GetSprite()
    {
        return craftSprite;
    }

    public string getName()
    {
        return craftName;
    }

    public virtual void PerformCraftInCombat()
    {

    }
}
