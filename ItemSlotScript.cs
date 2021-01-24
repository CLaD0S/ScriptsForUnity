using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlotScript : MonoBehaviour, IDropHandler
{
    [SerializeField] public ESlotType SlotType;
    public enum ESlotType
    {
        all,
        helmet,
        scapular,
        necklace,
        bracers,
        gloves,
        cuirass,
        cloak,
        leggings,
        boots,
        ring,
        sword,
        shield
    }
    [SerializeField] public Sprite[] ImageSlotType;

    private void Awake()
    {
        if (SlotType != ESlotType.all)
        {
            
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        if ((eventData.pointerDrag != null) && (eventData.pointerDrag.transform.parent != transform))
        {
            if (SlotType != ESlotType.all)
            {
                if (!Equals(SlotType.ToString(), eventData.pointerDrag.GetComponent<ItemScript>().ItemType.ToString()))
                {
                    return;
                }
            }
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
