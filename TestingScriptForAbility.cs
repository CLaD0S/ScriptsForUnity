using Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScriptForAbility : MonoBehaviour
{
    public Healing heal;
    private void Awake()
    {
        heal = gameObject.AddComponent<Healing>();
    }
}
