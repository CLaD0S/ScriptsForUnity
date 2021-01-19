using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IInterfaces;

public class Base_Items : MonoBehaviour, IPickUp, IPickOut, IUsed, IDestroing
{
    string _name;
    int _countUsed;

    public int _CountUsed
    {
        get => _countUsed;
        set => _countUsed = value;
    }
    public string _Name
    {
        get => _name;
        set => _name = value;
    }
    public virtual void PicUping(Transform parent)
    {
        Debug.Log($"������ {_name}");
        gameObject.transform.SetParent(parent);
        gameObject.SetActive(false);
    }
    public virtual void PicOuting()
    {
        Debug.Log($"�������� {_name}");
        gameObject.transform.parent = default;
        gameObject.SetActive(true);
    }
    public virtual void Used()
    {
        Debug.Log($"����������� {_name}");
        if (_countUsed > 0)
        {
            --_countUsed;
        }
        else
        {
            DestroyItem();
        }
    }
    public virtual void DestroyItem()
    {
        Destroy(this.gameObject);
    }
    public override string ToString()
    {
        return
            $"�������: {_name}," +
            $"���������� �������������: {_countUsed},";
    }
}
