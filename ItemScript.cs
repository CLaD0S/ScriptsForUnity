using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [Header("Поля базового класса")]
    [SerializeField]
    protected GameObject itemForWorld;
    [SerializeField]
    protected GameObject itemParent;
    [SerializeField]
    protected string itemName;
    [SerializeField]
    protected string description;
    [SerializeField]
    protected GameObject InventorySetPanel;
    [SerializeField]
    public EItemType ItemType;
    public enum EItemType
    {
        all, sword, body, helmet, ring, boots, hardword, Konsuella, sopojki, zone
    }
    protected void Awake()
    {
        if (itemName != "") { gameObject.name = itemName; } else { Debug.LogWarning("itemName = null"); }
        if (description != "") { transform.GetChild(0).GetChild(0).GetComponent<Text>().text = description; } else { Debug.LogWarning("description = null"); }
        InventorySetPanel = GameObject.Find("InventorySetPanel");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.GetComponent<Image>().raycastTarget = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.GetComponent<RectTransform>().anchoredPosition += eventData.delta;
        for (int i = 0; i <= InventorySetPanel.transform.childCount - 1; i++)
        {
            if (InventorySetPanel.transform.GetChild(i).GetComponent<ItemSlotScript>() != null)
            {
                if (Equals(InventorySetPanel.transform.GetChild(i).GetComponent<ItemSlotScript>().SlotType.ToString(), ItemType.ToString()))
                {
                    if (InventorySetPanel.transform.GetChild(i) != transform.parent)
                    {
                        InventorySetPanel.transform.GetChild(i).GetComponent<Image>().color = new Color(0, 1, 0);
                    }
                }
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.GetComponent<Image>().raycastTarget = true;
        transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        for (int i = 0; i <= InventorySetPanel.transform.childCount - 1; i++)
        {
            if (InventorySetPanel.transform.GetChild(i).GetComponent<ItemSlotScript>() != null)
            {
                if (Equals(InventorySetPanel.transform.GetChild(i).GetComponent<ItemSlotScript>().SlotType.ToString(), ItemType.ToString()))
                {
                    InventorySetPanel.transform.GetChild(i).GetComponent<Image>().color = new Color(1, 1, 1);
                }
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine("SlowShow");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        StopCoroutine("SlowShow");
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
    }
    protected IEnumerator SlowShow()
    {
        yield return new WaitForSeconds(1);
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button.ToString() != "Left")
        {
            transform.GetChild(1).gameObject.SetActive(true);
            GetComponent<ItemUsed_Script>().Useding(itemParent);
        }
    }
}
