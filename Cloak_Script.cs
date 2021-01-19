using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloak_Script : Base_Items
{
    public Cloak_Script()
    {
        _Name = "Плащ";
        _CountUsed = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(ToString());
    }
}
