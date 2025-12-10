
using UnityEngine;
using System;
using System.Collections.Generic;
[Serializable]
public class Weapon : MonoBehaviour
{

    //Declaration Variable
    [SerializeField] private string _name;
    [SerializeField] private Stats _bonusStats;
    [SerializeField] private float _rateOfFire;
    [SerializeField] private float _lifespan;
    [SerializeField] private BulletHero _bulletHero;
    private static List<Weapon> _listWeapons = new List<Weapon>();
    //Constructor
    public Weapon(string name, Stats bonusStats, float rateOfFire, float lifespan, BulletHero bulletHero)
    {
        _name = name;
        _bonusStats = bonusStats;
        _rateOfFire = rateOfFire;
        _lifespan = lifespan;
        _bulletHero = bulletHero;
    }

    public Weapon() { }

    //Getter
    public string GetName()
    { return _name; }

    public Stats GetBonusStats()
    { return _bonusStats; }

    public float GetRateOfFire()
    { return _rateOfFire; }

    public float GetLifeSpan()
    { return _lifespan; }

    public BulletHero GetBulletHero()
    { return _bulletHero; }

    public List<Weapon> GetListWeapon()
    { return _listWeapons; }
    //Setter
    public void SetName(string name)
    {
        if (!string.IsNullOrEmpty(name))
        { _name = name; }
    }

    public void SetBonusStats(Stats bonusStats)
    { _bonusStats = bonusStats; }

    public void SetRateOfFire(float rateOfFire)
    { _rateOfFire = rateOfFire; }

    public void SetLifeSpan(float lifespan)
    { _lifespan = lifespan; }

    public void SetNameBulletHero(BulletHero bulletHero)
    { _bulletHero = bulletHero; }

    //Funzionalità acquisizione arma
    public static void SetWeapon(Weapon weapon)
    {
        bool foundWeapon = false;
        for (int i = 0; i < _listWeapons.Count; i++)
        {
            if (_listWeapons[i]._name.Equals(weapon._name))
            {
                foundWeapon = true;
                return;
            }

        }
        if (foundWeapon)
        {
            //Gestione LevelUP
        }
        else
        {
            _listWeapons.Add(weapon);
        }

    }

}
