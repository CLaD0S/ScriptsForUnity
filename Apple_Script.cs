using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple_Script : Base_Items
{
    public Apple_Script()
    {
        _Name = "яблоко";
        _CountUsed = 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(ToString());
    }
}