using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveEnemy : MonoBehaviour
{
    protected float _speed;
    protected Player _player; 


    protected Vector2 StartPosition; //mi da la posizione iniziale dove è posizionato L'enemy
    [SerializeField] protected bool ThereIsPLayer;

    //variabili per gestire la spinta subita dal proiettiele nemico(Player)
    protected bool isKnocked;
    public float knockSpeed;
    public Vector2 knockTarget;
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

    public bool IsKnocked
    {
        get { return isKnocked; }
        set { isKnocked = value; }
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
    public void StartKnockback(Vector2 dir, float force)
    {
        knockTarget = (Vector2)transform.position + dir;
        knockSpeed = force;
        isKnocked = true;
    }
    public abstract void LogicMove();

}

