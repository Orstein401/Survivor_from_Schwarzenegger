using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] int _hp;
    Mover _mover = new Mover();
    Rigidbody2D _rb;
    LifeController LifeArnlodino = new LifeController();
    // Start is called before the first frame update

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        LifeArnlodino.SetHp(_hp);

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _mover.SetPositionPlayer();
    }

    private void FixedUpdate()
    {

        _mover.Movement(_rb, _speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") ||
            collision.gameObject.CompareTag("Enemy Bullet"))
        {
            //
        }
    }
}
