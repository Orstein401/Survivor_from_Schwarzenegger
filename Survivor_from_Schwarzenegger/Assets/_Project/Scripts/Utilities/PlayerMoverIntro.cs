using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoverIntro : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector2 _velocity;
    Rigidbody2D _rb;
    private float _h;
    private float _v;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        _velocity.x = _h;
        _velocity.y = _v;
        _velocity = _velocity.normalized;
        _rb.velocity = _velocity * _speed;

    }
}
