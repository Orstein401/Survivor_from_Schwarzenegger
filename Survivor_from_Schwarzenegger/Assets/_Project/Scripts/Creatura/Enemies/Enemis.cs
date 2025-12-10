using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemis:MonoBehaviour
{
    //variabili che servono a tutti i nemici
    [SerializeField]protected int _hp;
    [SerializeField]protected float _speed;
    [SerializeField]protected Player _player; //fatta Serialize per evitare di cercare ogni volta con il  FindAnyObjectByType<Player>();

    private void Awake()
    {
    
        if( _player == null)
        {
            _player = FindAnyObjectByType<Player>(); // è sempre presente in caso non dovesse essere messo niente nel serializeFIeld
        }
       
    }
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
       
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, Speed * Time.deltaTime);
    }




}
