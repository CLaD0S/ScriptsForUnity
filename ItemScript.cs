using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
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
    }

    private IEnumerator SlowShow()
    {
        yield return new WaitForSeconds(1);
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
