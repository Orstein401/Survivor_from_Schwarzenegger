using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveEnemy : MonoBehaviour
{
    protected float _speed;
    protected Player _player; 
    protected Vector2 StartPosition; //mi da la posizione iniziale dove è posizionato L'enemy
    [SerializeField] protected bool ThereIsPLayer;

    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }
    public bool IsPlayer
    {
        get { return ThereIsPLayer; }
        set { ThereIsPLayer = value; }
    }

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
    public void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, Speed * Time.deltaTime);
    }
    public abstract void LogicMove();
}

