using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Player : MonoBehaviour
{
    [SerializeField] private int _hp;
    [SerializeField] private Stats _baseStats;
    [SerializeField] BulletHero[] _bulletHero;
    private Weapon _weapon;
    Mover _mover = new Mover();
    Shoot _shoot = new Shoot();
    Rigidbody2D _rb;
    LifeController LifeHero = new LifeController();
    // Start is called before the first frame update

    private void Awake()
    {
        //Setting info principali del Player
        _rb = GetComponent<Rigidbody2D>();
        LifeHero.SetHp(_hp);

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _mover.SetPositionPlayer();
        _shoot.Shooter(_weapon.GetListWeapon(), _bulletHero);
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

        if (collision.gameObject.CompareTag("Ammo"))
        {
            Weapon ammo = gameObject.GetComponent<Weapon>();
            Weapon.SetWeapon( ammo);
        }
    }
}
