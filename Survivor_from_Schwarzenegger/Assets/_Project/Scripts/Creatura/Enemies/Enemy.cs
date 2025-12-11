using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected Stats stats;
    [SerializeField] protected int _hp;
    [SerializeField] protected float _walkingSpeed = 2;
    [SerializeField] protected Player player; //fatta Serialize per evitare di cercare ogni volta con il  FindAnyObjectByType<Player>()
    [SerializeField] protected float _range;

    protected MoveEnemy typeMove;
    protected TriggerRange IsTrigger;
    public LifeController lifeEnemy;
    [SerializeField] DropAmmo bulletDrop;


    protected virtual void Awake()
    {
        typeMove = GetComponent<MoveEnemy>();
        lifeEnemy = GetComponent<LifeController>();
        IsTrigger = GetComponent<TriggerRange>();
        if (lifeEnemy == null)
        {
            lifeEnemy = gameObject.AddComponent<LifeController>();
        }
        if (typeMove == null)
        {
            typeMove = gameObject.AddComponent<MoveEnemy>();
        }
        if (IsTrigger == null)
        {
            IsTrigger = gameObject.AddComponent<TriggerRange>();
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

        lifeEnemy.SetHp(_hp);
    }

    public void Drop()
    {
       DropAmmo bullet = Instantiate(bulletDrop);
        bullet.transform.position = gameObject.transform.position;
    }

}
