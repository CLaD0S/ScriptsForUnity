using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlotScript : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        if ((eventData.pointerDrag != null) && (eventData.pointerDrag.transform.parent != transform))
        {
            if (transform.childCount > 0)
            {
                Transform move = transform.GetChild(0);
                move.SetParent(eventData.pointerDrag.transform.parent);
                move.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            }
            eventData.pointerDrag.transform.SetParent(transform);
        }
    }
}
