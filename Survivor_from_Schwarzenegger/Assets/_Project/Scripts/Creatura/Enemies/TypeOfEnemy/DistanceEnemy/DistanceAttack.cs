using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceAttack : MonoBehaviour
{
    public BulletEnemy bulletPrefab;
    public void ShootAtPlayer( Transform player)
    {
        Vector2 direction =player.position - gameObject.transform.position;
        direction.Normalize();
        BulletEnemy bullet = Instantiate(bulletPrefab);
        bullet.transform.position = gameObject.transform.position;
        bullet.SetUpDirecton(direction);
    }
}

