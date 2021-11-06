using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class DraggableIcon : MonoBehaviour
{
    public Craft craft;
    public CraftPoolButton originalButton;

    public void Init(Craft craft, CraftPoolButton originalButton)
    {
        this.craft = craft;
        Image craftImage = GetComponent<Image>();
        craftImage.sprite = craft.GetSprite();
        this.originalButton = originalButton;
        UpdateLocalPosition();
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
            StartCoroutine(SelfDestory());
        }
        else
        {
            UpdateLocalPosition();

        }
    }

    private void UpdateLocalPosition()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        if (rectTransform)
        {
            Vector2 vecMouse = this.CurrMousePosition(transform);
            rectTransform.localPosition = new Vector3(vecMouse.x, vecMouse.y, 0);
        }
    }

    public Vector2 CurrMousePosition(Transform thisTrans)
    {
        Vector2 vecMouse;
        RectTransform parentRectTrans = thisTrans.parent.GetComponent<RectTransform>();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTrans, Input.mousePosition, null, out vecMouse);
        return vecMouse;
    }


    private IEnumerator SelfDestory()
    {
        yield return new WaitForEndOfFrame();
        Destroy(this.gameObject);
    }
}
