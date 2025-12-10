
using UnityEngine;
using System;
[Serializable]
public class Weapon
{

    //Declaration Variable
    [SerializeField] private string _name;
    [SerializeField] private Stats _bonusStats;
    [SerializeField] private float _rateOfFire;
    [SerializeField] private float _lifespan;
    //Constructor
    public Weapon(string name, Stats bonusStats, float rateOfFire, float lifespan)
    {
        _name = name;
        _bonusStats = bonusStats;
        _rateOfFire = rateOfFire;
        _lifespan = lifespan;
    }

    //Getter
    public string GetName()
    { return _name; }

    public Stats GetBonusStats()
    { return _bonusStats; }

    public float GetRateOfFire()
    { return _rateOfFire; }

    public float GetLifeSpan()
    { return _lifespan; }

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

}
