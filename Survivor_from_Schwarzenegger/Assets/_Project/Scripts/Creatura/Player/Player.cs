using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Player : MonoBehaviour
{
    [SerializeField] int _hp;
    [SerializeField] Stats BaseStats;
    [SerializeField] List<Weapon> Weapon;

    Mover _mover = new Mover();
    Rigidbody2D _rb;
    LifeController LifeArnoldino = new LifeController();
    // Start is called before the first frame update

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        LifeArnoldino.SetHp(_hp);

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

        _mover.Movement(_rb, BaseStats.spd);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") ||
            collision.gameObject.CompareTag("Enemy Bullet"))
        {
            // Gestone take damege da definire.
        }
    }
}
