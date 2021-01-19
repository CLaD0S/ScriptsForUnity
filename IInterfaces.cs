using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IInterfaces
{
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
        void Used();
    }
    interface IDestroing
    {
        void DestroyItem();
    }
}
