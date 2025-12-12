using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muoviti : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] private float speed;
    Vector2 _velocity;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void SetAndNormalize(Vector2 direction)
    {

        if (direction.magnitude > 1)
        {
            direction /= direction.magnitude;
        }
        _velocity = direction;
    }

    public void FixedUpdate()
    {
        _rb.velocity = _velocity * speed;
    }


    float h;
    float v;
    Vector2 direction;


    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        direction = new Vector2(h, v);

        if (h != 0 || v != 0)
        {
            SetAndNormalize(direction);
            
        }

    }
}
