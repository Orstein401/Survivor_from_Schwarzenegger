using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody2D _rb;
    private Vector2 dir;
    private Vector2 posPlayer;
    private float bulletForce = 3;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void SetUp(Vector2 direction)
    {
        dir = direction;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, 5f);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            MoveEnemy enemy = collision.gameObject.GetComponent<MoveEnemy>();
            enemy.StartKnockback(dir, bulletForce);
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + dir * (speed * Time.fixedDeltaTime));
    }
}
