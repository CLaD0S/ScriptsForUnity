using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IInterfaces;
public class ItemUsed_Script : ItemScript, IUsed, IBaffDamage, IHeiling
{
    [Header("Поля используемых предметов")]
    [SerializeField]
    private int countUsedItem;
    public void BaffDamage()
    {
        if (itemParent.GetComponent<MonoBehaviour>().GetType().GetField("_damage") != null)
        {
            Debug.Log("Бафаю урон " + itemParent.gameObject.name);
        }
        else
        {
            Debug.Log(itemParent.gameObject.name + " лишен умения наносить урон");
        }
    }
    public void Heiling()
    {
        if (itemParent.GetComponent<MonoBehaviour>().GetType().GetProperty("HitPoint") != null)
        {
            Debug.Log("Восстанавливаю здоровье " + itemParent.gameObject.name);
        }
        else
        {
            Debug.Log(itemParent.gameObject.name + " лишен умения восстанавливать здоровье");
        }
    }
    public void Useding(GameObject UsedChar)
    {
        if (itemParent != null)
        {
            Debug.Log("Меня использует " + itemParent.gameObject.name);

            BaffDamage();
            Heiling();
            Debug.Log("Осталось " + --countUsedItem + " использований");
            if (countUsedItem <= 0)
                Destroy(gameObject);
        }
        else
        {
            Debug.Log(itemParent.gameObject.name + " что я такое?");
        }
    }
}