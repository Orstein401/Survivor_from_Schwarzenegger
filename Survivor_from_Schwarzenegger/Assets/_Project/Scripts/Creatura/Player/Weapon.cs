
using UnityEngine;
using System;
using System.Collections.Generic;
[Serializable]
public enum Ammo
{
    Shotgun = 0,
    Spada = 1,
    Laser = 2,
    DannyDeVito = 3,
    Gatling = 4,
    Libri = 5,

}
[Serializable]
public class Weapon
{

    //Declaration Variable
    [SerializeField] private Ammo _nameAmmo;
    [SerializeField] private Stats _bonusStats;
    [SerializeField] private float _rateOfFire;
    [SerializeField] private float _lifespan;
    private static List<Weapon> _listWeapons = new List<Weapon>();
    //Constructor
    public Weapon(Ammo nameAmmo, Stats bonusStats, float rateOfFire, float lifespan)
    {
     
        _nameAmmo = nameAmmo;
        _bonusStats = bonusStats;
        _rateOfFire = rateOfFire;
        _lifespan = lifespan;
    }

    public Weapon() { }

    //Getter
    public Ammo GetNameAmmo()
    { return _nameAmmo; }

    public Stats GetBonusStats()
    { return _bonusStats; }

    public float GetRateOfFire()
    { return _rateOfFire; }

    public float GetLifeSpan()
    { return _lifespan; }

    public List<Weapon> GetListWeapon()
    { return _listWeapons; }
    //Setter
    public void SetNameAmmo(Ammo nameAmmo)
    {
        _nameAmmo = nameAmmo;
    }

    public void SetBonusStats(Stats bonusStats)
    { _bonusStats = bonusStats; }

    public void SetRateOfFire(float rateOfFire)
    { _rateOfFire = rateOfFire; }

    public void SetLifeSpan(float lifespan)
    { _lifespan = lifespan; }

    //Funzionalità acquisizione arma
    public static void SetWeapon(Weapon weapon)
    {
        bool foundWeapon = false;
        for (int i = 0; i < _listWeapons.Count; i++)
        {
            if (_listWeapons[i]._nameAmmo.Equals(weapon._nameAmmo))
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
