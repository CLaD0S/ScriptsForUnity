using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle_HP_Script : Base_Items
{
    public Bottle_HP_Script()
    {
        _Name = "Ёликсир здоровь€";
        _CountUsed = 4;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(ToString());
    }
}
