using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class BulletHero : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private Ammo _nameAmmo = Ammo.Spada;
    [SerializeField] private float _speed;
    private Vector3 _newDirection;
    private float bulletForce = 3;


    //Nel fixed update calcolo il movimento del bullet ( movimento + velocità)
    private void Update()
    {
        transform.position = transform.position + _newDirection * _speed * Time.deltaTime;
    }


    public void MovementBullet(Vector2 dirPlayer)
    {
        _newDirection = dirPlayer.normalized; //indico la direzione che deve prendere il mio bullet
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            MoveEnemy enemyPos = collision.gameObject.GetComponent<MoveEnemy>();
            enemy.knockBack.StartKnockback(_newDirection, bulletForce);
            Debug.Log("vita prima"+enemy.lifeEnemy.GetHp());
            enemy.lifeEnemy.TakeDamage(_damage);
            Debug.Log("vita dopo" + enemy.lifeEnemy.GetHp());

            if (!enemy.lifeEnemy.IsAlive())
            {
                enemy.Drop();
                Destroy(collision.gameObject, 2f);
                Debug.Log("è morto");
            }
            else
            {
                Debug.Log(enemy.lifeEnemy.GetHp()+"se è ancora vivo");
            }
                Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            //Raffaele te lo ammolo a te
        }
    }

    public BulletHero() { }

    public int GetDamage()
    { return _damage; }

    public Ammo GetNameAmmo()
    { return _nameAmmo; }

    public void SetDamage(int damage)
    { _damage = damage; }

    public void SetNameAmmo(Ammo nameAmmo)
    { _nameAmmo = nameAmmo; }
}
