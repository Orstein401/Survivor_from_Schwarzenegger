using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _walkingSpeed = 2;
    [SerializeField] private Player player; //fatta Serialize per evitare di cercare ogni volta con il  FindAnyObjectByType<Player>();
    [SerializeField] private float _range;

    MoveEnemy typeMove;
    TriggerRange IsTrigger;

    private void Awake()
    {
        typeMove = GetComponent<MoveEnemy>();
        IsTrigger = GetComponent<TriggerRange>();
        if (player == null)
        {
            player = FindAnyObjectByType<Player>(); // è sempre presente in caso non dovesse essere messo niente nel serializeFIeld
        }
    }

    private void Start()
    {
        if (typeMove != null)
        {
            typeMove.Player = player;
        }
        else
        {
            Debug.Log("ce un problema in type");
        }
        if (IsTrigger)
        {
            IsTrigger.Player = player;
            IsTrigger.range = _range;
        }
        else
        {
            Debug.Log("ce un problema in Itrigger");
        }

        //typeMove.Player = player;
        //IsTrigger.Player = player;
        //IsTrigger.range = _range;
    }
    private void Update()
    {
        if (IsTrigger.IsNearPLayer())
        {
            typeMove.Speed = _speed;
            typeMove.ChasePlayer();
        }
        else
        {
            typeMove.Speed = _walkingSpeed;
            typeMove.LogicMove();
        }

    }
}
