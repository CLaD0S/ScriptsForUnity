using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IInterfaces;
public class ItemUsed_Script : ItemScript, IUsed
{
    [Header("���� ������������ ���������")]
    [SerializeField]
    private int countUsedItem;

    public void Useding(GameObject UsedChar)
    {
        if (itemParent != null)
        {
            Debug.Log("���� ���������� " + itemParent.gameObject.name);
            //GetComponent<TestingScriptForItems>().enabled = true;
            itemParent.AddComponent<TestingScriptForItems>();
            Debug.Log("�������� " + --countUsedItem + " �������������");
            if (countUsedItem <= 0)
                Destroy(gameObject);
        }
        else
        {
            Debug.Log(itemParent.gameObject.name + " ��� � �����?");
        }
    }
}