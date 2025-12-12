using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Player : MonoBehaviour
{

    [SerializeField] private Stats _baseStats;
    [SerializeField] BulletHero[] _bulletHero;
    [SerializeField] private List<Weapon> _firstWeapon;
    private List<Weapon> _listWeapon;
    Mover _mover = new Mover();
    Shoot _shoot = new Shoot();
    Rigidbody2D _rb;
    public LifeController LifeHero;
    // Start is called before the first frame update

    private void Awake()
    {
        //Setting info principali del Player
        _rb = GetComponent<Rigidbody2D>();
       
        Weapon.SetWeapon(_firstWeapon[0]);
        _listWeapon = Weapon.GetListWeapon();

        //ora che lifecontroller è un monoBehavior non si può più fare lifehero= new LifeController, ma tocca per forza prendere il componente
        LifeHero = GetComponent<LifeController>();
        if (LifeHero == null)
        {
            LifeHero = gameObject.AddComponent<LifeController>();
        }
    }
    void Start()
    {
        LifeHero.SetHp(_baseStats._hp);
    }

    // Update is called once per frame
    void Update()
    {
        _listWeapon = Weapon.GetListWeapon();
        _mover.SetPositionPlayer();
        _shoot.Shooter(_listWeapon, _bulletHero, gameObject, _mover.GetPositionPlayer());
    }

    private void FixedUpdate()
    {

        _mover.Movement(_rb, _baseStats._spd);
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
