using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : Bullet
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            Debug.Log("vita prima" + player.LifeHero.GetHp());
            player.LifeHero.TakeDamage(_damage);
            Debug.Log("vita dopo" + player.LifeHero.GetHp());

            if (!player.LifeHero.IsAlive())
            {
                Destroy(collision.gameObject, 2f);
                Debug.Log("è morto");
            }
            else
            {
                Debug.Log(player.LifeHero.GetHp() + "se è ancora vivo");
            }
            Destroy(gameObject);
        }

    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
