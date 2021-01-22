using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IInterfaces;
public class ItemUsed_Script : ItemScript, IUsed, IBaffDamage, IHeiling
{
    [Header("���� ������������ ���������")]
    [SerializeField]
    private int countUsedItem;
    public void BaffDamage()
    {
        if (itemParent.GetComponent<MonoBehaviour>().GetType().GetField("_damage") != null)
        {
            Debug.Log("����� ���� " + itemParent.gameObject.name);
        }
        else
        {
            Debug.Log(itemParent.gameObject.name + " ����� ������ �������� ����");
        }
    }
    public void Heiling()
    {
        if (itemParent.GetComponent<MonoBehaviour>().GetType().GetProperty("HitPoint") != null)
        {
            Debug.Log("�������������� �������� " + itemParent.gameObject.name);
        }
        else
        {
            Debug.Log(itemParent.gameObject.name + " ����� ������ ��������������� ��������");
        }
    }
    public void Useding(GameObject UsedChar)
    {
        if (itemParent != null)
        {
            Debug.Log("���� ���������� " + itemParent.gameObject.name);

            BaffDamage();
            Heiling();
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