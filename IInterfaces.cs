using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IInterfaces
{
    interface ITiming
    {
        void Timing();
    }
    interface IHeiling
    {
        void Heiling();
    }
    interface IDamaging
    {
        void Damaging();
    }
    interface IBaffDamage
    {
        void BaffDamage();
    }
    interface IMaximingHitPoint
    {
        void MaximingHitPoint();
    }
    interface IPickUp
    {
        void PicUping(Transform parent);
    }
    interface IPickOut
    {
        void PicOuting();
    }
    interface IUsed
    {
        void Useding(GameObject UsedChar);
    }
    interface IDestroing
    {
        void DestroyItem();
    }
}
