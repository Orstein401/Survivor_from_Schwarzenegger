using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected Player _player; //fatta Serialize per evitare di cercare ogni volta con il  FindAnyObjectByType<Player>();
    protected Vector2 StartPosition; //mi da la posizione iniziale dove è posizionato L'enemy
    [SerializeField] protected bool ThereIsPLayer;

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
  
    protected virtual void Awake()
    {
        StartPosition = transform.position;
        if (_player == null)
        {
            _player = FindAnyObjectByType<Player>(); // è sempre presente in caso non dovesse essere messo niente nel serializeFIeld
        }

    }
    public virtual void LogicMove()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, Speed * Time.deltaTime);
    }
}
