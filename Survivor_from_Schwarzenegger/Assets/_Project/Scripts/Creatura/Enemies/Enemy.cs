using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float _speed = 5;
    [SerializeField] protected float _walkingSpeed = 2;
    [SerializeField] protected Player player; //fatta Serialize per evitare di cercare ogni volta con il  FindAnyObjectByType<Player>();
    [SerializeField] protected float _range;

    protected MoveEnemy typeMove;
    protected TriggerRange IsTrigger;

    protected virtual void Awake()
    {
        typeMove = GetComponent<MoveEnemy>();
        IsTrigger = GetComponent<TriggerRange>();
        if(typeMove == null)
        {
            typeMove = gameObject.AddComponent<MoveEnemy>();
        }
        if(IsTrigger == null)
        {
            IsTrigger= gameObject.AddComponent<TriggerRange>();
        }
        if (player == null)
        {
            player = FindAnyObjectByType<Player>(); // è sempre presente in caso non dovesse essere messo niente nel serializeFIeld
        }
    }

    protected virtual void Start()
    {
        typeMove.Player = player;
        IsTrigger.Player = player;
        IsTrigger.range = _range;
    }
    private void Update()
    {
        if (IsTrigger.IsNearPLayer())
        {
            typeMove.Speed = _speed;

        }
        else
        {
            typeMove.Speed = _walkingSpeed;
            typeMove.LogicMove();
        }
    }

}
