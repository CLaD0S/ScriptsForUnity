using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField]
    protected GameObject itemForWorld;
    [SerializeField]
    protected string itemName;
    [SerializeField]
    protected string description;
    [SerializeField]
    public EItemType ItemType;
    public enum EItemType
    {
        all, sword, body, helmet
    }
    protected void Awake()
    {
        if (itemName != "") { gameObject.name = itemName; } else { Debug.LogWarning("itemName = null"); }
        if (description != "") { transform.GetChild(0).GetChild(0).GetComponent<Text>().text = description; } else { Debug.LogWarning("description = null"); }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.GetComponent<Image>().raycastTarget = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.GetComponent<RectTransform>().anchoredPosition += eventData.delta;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.GetComponent<Image>().raycastTarget = true;
        transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
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
        }
    }
}
