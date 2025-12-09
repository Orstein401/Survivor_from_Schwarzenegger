using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private float _h;
    private float _v;
    private Vector2 _position;
    private Rigidbody2D _rb;
    [SerializeField] float _speed;
    // Start is called before the first frame update

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        _position.x = _h;
        _position.y = _v;
        if (_position.magnitude > 1)
        {
            _position = _position / _position.magnitude;

        }
        _rb.MovePosition(_rb.position + _position * (_speed * Time.deltaTime));
    }
}
