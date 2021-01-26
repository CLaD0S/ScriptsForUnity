using Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestingScriptForAbility : MonoBehaviour
{
    public Image panelStatus;
    public GameObject panels;

    public List<BaseEffect> effects;
    public List<Sprite> images;
    private void Awake()
    {
        effects.Add(gameObject.AddComponent<Healing>());
        effects.Add(gameObject.AddComponent<Damaging>());
        for (int i = 0; i < images.Count; i++)
        {
            GameObject slots = Instantiate(panels, panelStatus.transform);
            slots.GetComponent<Image>().sprite = images[i];
        }
    }
}
