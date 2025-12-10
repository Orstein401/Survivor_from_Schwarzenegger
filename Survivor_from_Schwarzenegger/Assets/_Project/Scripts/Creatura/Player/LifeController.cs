using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LifeController
{
    [SerializeField] private int _hp;
    // Start is called before the first frame update

    //Constructor
    public LifeController()
    { }
    //Getter
    public float GetHp() => _hp;

    //Setter
    public void SetHp(int hp)
    { _hp = hp; }

    //Functionality
    public void TakeDamage(int damage)
    {
        _hp = Mathf.Max(0, _hp - damage);
    }

    public void AddHp(int hp)
    { _hp += hp; }
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
