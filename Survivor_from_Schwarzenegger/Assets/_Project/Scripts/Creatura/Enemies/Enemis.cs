using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemis:MonoBehaviour
{
    protected int _hp;
    protected float _speed;

    public int Hp
    {
        get { return _hp; }
        set { _hp = value; }
    }
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    public virtual void LogicMove()
    {

    }




}
