using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class BulletHero : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private Ammo _nameAmmo = Ammo.Spada;
    [SerializeField] private float _speed;
    private Vector3 _newDirection;

    //Nel fixed update calcolo il movimento del bullet ( movimento + velocità)
    private void Update()
    {
        transform.position = transform.position + _newDirection * _speed * Time.deltaTime;
    }



    public void MovementBullet(Vector2 dirPlayer)
    {
        _newDirection = dirPlayer * 2; //indico la direzione che deve prendere il mio bullet


    }

    public BulletHero() { }

    public int GetDamage()
    { return _damage; }

    public Ammo GetNameAmmo()
    { return _nameAmmo; }

    public void SetDamage(int damage)
    { _damage = damage; }

    public void SetNameAmmo(Ammo nameAmmo)
    { _nameAmmo = nameAmmo; }
}
