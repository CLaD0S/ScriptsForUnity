using Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusScript : MonoBehaviour
{
    private GameObject panelStatus;
    private void Awake()
    {
        panelStatus = GameObject.Find("PanelStatus");
    }
    private void OnTransformChildrenChanged()
    {
        for (int i = 0; i < panelStatus.transform.childCount; i++)
        {
            Destroy(panelStatus.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).tag == "Effect")
            {
                GameObject spriteEffect = Instantiate(new GameObject(), panelStatus.transform);
                RawImage imageEffect = spriteEffect.AddComponent<RawImage>();
                imageEffect.texture = transform.GetChild(i).GetComponent<BaseEffect>().SpriteEffect.texture;
            }
        }
    }
}
