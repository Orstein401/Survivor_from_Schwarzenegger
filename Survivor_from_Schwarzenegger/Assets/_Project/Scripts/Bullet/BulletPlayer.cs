using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : Bullet
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            MoveEnemy enemy = collision.gameObject.GetComponent<MoveEnemy>();
            enemy.StartKnockback(dir, bulletForce);
            Destroy(gameObject);
        }
    }
}
