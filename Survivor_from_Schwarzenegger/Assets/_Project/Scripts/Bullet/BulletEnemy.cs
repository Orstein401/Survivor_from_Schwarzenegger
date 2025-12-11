using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody2D _rb;
    private Vector2 dir;
    private Vector2 posPlayer;

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
            posPlayer = collision.transform.position;
            posPlayer += dir;
            collision.transform.position = posPlayer;
            Destroy(gameObject);
        }
       
    }
    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + dir * (speed * Time.fixedDeltaTime));
    }
}
