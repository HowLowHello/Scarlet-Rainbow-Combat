using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DraggableIcon : MonoBehaviour
{
    public Craft craft;
    public CraftPoolButton originalButton;

    public void Init(Craft craft)
    {
        this.craft = craft;
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = craft.GetSprite();
    }

    public Craft GetCraft()
    {
        return craft;
    }

    private void Update()
    {
        if (originalButton == null || craft == null)
        {
            Destroy(this.gameObject);
            Debug.LogWarning("Draggable Icon is not correct");
            return;
        }
        if (!originalButton.IsButtonDown())
        {
            Destroy(this.gameObject);
        }
        else
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(worldPos.x, worldPos.y, 0);
        }
    }
}
