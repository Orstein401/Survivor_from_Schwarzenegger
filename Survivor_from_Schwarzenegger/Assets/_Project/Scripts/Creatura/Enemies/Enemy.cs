using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected Stats stats;
    [SerializeField] protected float _walkingSpeed = 2;
    [SerializeField] protected Player player; //fatta Serialize per evitare di cercare ogni volta con il  FindAnyObjectByType<Player>()
    [SerializeField] protected float _range;

    protected MoveEnemy typeMove;
    protected TriggerRange IsTrigger;
    public LifeController lifeEnemy;
    public KnockBack knockBack;

    [SerializeField] DropAmmo bulletDrop;


    protected virtual void Awake()
    {
        knockBack = GetComponent<KnockBack>();
        typeMove = GetComponent<MoveEnemy>();
        lifeEnemy = GetComponent<LifeController>();
        IsTrigger = GetComponent<TriggerRange>();
        if (knockBack == null)
        {
            knockBack = gameObject.AddComponent<KnockBack>();
        }
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

        lifeEnemy.SetHp(10000);
    }

    public void Drop()
    {
        DropAmmo bullet = Instantiate(bulletDrop);
        bullet.transform.position = gameObject.transform.position;
    }


//    scrivo in chat
//Enemy e = Instantiate(prefab );
//    e.transform.position = new Vector3(qualcosa );
//    e.Setup();

//EPICODE
//epicode.com
//21:39
//può essere randomico
//o può essere sequenziale
//tipo il primo in (0,0,0)
//il secondo in (0,-1,0)
//il terzo in (0,.-2,0)
//esatto
//ora vado che così sento gli altri al volo



}
