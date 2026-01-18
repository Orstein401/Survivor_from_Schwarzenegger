using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Player : MonoBehaviour
{
    [SerializeField] public int _hp;
    [SerializeField] public Stats _baseStats;
    [SerializeField] BulletHero[] _bulletHero;
    [SerializeField] private List<Weapon> _firstWeapon;
    private List<Weapon> _listWeapon;
    Mover _mover = new Mover();
    Shoot _shoot = new Shoot();
    Rigidbody2D _rb;
    public LifeController LifeHero;
    Camera _camera;
    // Start is called before the first frame update

    private void Awake()
    {
        //Setting info principali del Player
        _rb = GetComponent<Rigidbody2D>();

        Weapon.SetWeapon(_firstWeapon[0]);
        _listWeapon = Weapon.GetListWeapon();
        _camera = Camera.main;
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
        _shoot.Shooter(_listWeapon, _bulletHero, gameObject, _mover.GetPositionPlayer(), _camera);
    }

    private void FixedUpdate()
    {

        _mover.Movement(_rb, _baseStats._spd);
    }
}
