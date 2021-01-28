using Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior_item_script : MonoBehaviour
{
    [SerializeField] private BaseEffect effect;
    private void Awake()
    {
        effect = gameObject.AddComponent<Healing>();
        effect.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Character")
        {
            GetComponent<CircleCollider2D>().enabled = false;
            transform.parent.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f, 0.2f);
            effect.gameObject.transform.SetParent(collision.transform);
            effect.enabled = true;
        }
    }
}