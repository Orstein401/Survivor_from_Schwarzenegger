using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scemo : MonoBehaviour
{
    public muoviti _Scemo;
    public float range;


    public bool IsNearPLayer()
    {
        if (Vector2.Distance(transform.position, _Scemo.transform.position) <= range)
        {
            return true;
        }
        return false;

    }
}
