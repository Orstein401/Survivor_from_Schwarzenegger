using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceEnemy : Enemy
{
    [SerializeField] BulletEnemy _bulletPrefab;
    DistanceAttack Attack;
    private float lastTimeShoot;
    [SerializeField] float fireRate;

    protected override void Awake()
    {
        base.Awake();
        Attack = GetComponent<DistanceAttack>();
        if (Attack == null)
        {
            Attack = gameObject.AddComponent<DistanceAttack>();
        }
    }
    protected override void Start()
    {
        base.Start();
        Attack.bulletPrefab = _bulletPrefab;
    }
    void Update()
    {

        if (typeMove.IsKnocked)
        {
            transform.position = Vector2.MoveTowards(transform.position, typeMove.knockTarget, typeMove.knockSpeed * Time.deltaTime);
        }
        else
        {
            if (IsTrigger.IsNearPLayer())
            {
                if (Time.time - lastTimeShoot > fireRate)
                {
                    lastTimeShoot = Time.time;
                    Attack.ShootAtPlayer(player.transform);
                }

            }
            else
            {
                typeMove.Speed = _walkingSpeed;
                typeMove.LogicMove();
            }
        }
        if (Vector2.Distance(transform.position, typeMove.knockTarget) < 0.05f)
        {
            typeMove.IsKnocked = false;
        }
    }
}
