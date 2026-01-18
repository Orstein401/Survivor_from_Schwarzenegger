using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float lifeSpan;
    [SerializeField] protected float bulletForce = 3;
    [SerializeField] protected int _damage;
    protected Rigidbody2D _rb;
    protected Vector2 dir;
   
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void SetUpDirecton(Vector2 direction)
    {
        dir = direction;
    }
    private void OnEnable()
    {
        Destroy(gameObject, lifeSpan);
    }
    protected virtual void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + dir * (speed * Time.fixedDeltaTime));
    }
  
}
