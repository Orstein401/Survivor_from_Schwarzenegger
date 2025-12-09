using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LifeController
{
    [SerializeField] protected float _hp;
    // Start is called before the first frame update

    //Constructor
    public LifeController()
    { }
    //Getter
    public float GetHp() => _hp;

    //Setter
    public void SetHp(float hp)
    { _hp = hp; }

    public void TakeDamage(float damage)
    {
        _hp = Mathf.Max(0, _hp - damage);
    }

    public bool IsAlive()
    {
        if (_hp > 0)
        { return true; }
        else
        {
            return false;
        }
    }

}
