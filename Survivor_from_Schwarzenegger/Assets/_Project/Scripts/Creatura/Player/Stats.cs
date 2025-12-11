using System;
using System.Security.Cryptography;
using UnityEngine;

[Serializable]

public struct Stats
{

    [SerializeField] public int _atk;
    [SerializeField] public int _shd;
    [SerializeField] public int _spd;
    [SerializeField] public int _hp;

    //Construct
    public Stats(int atk, int shd, int spd, int hp)
    {
        _atk = atk;
        _shd = shd;
        _spd = spd;
        _hp = hp;
    }

    //Functionality
    public static Stats Sum(Stats S1, Stats S2)
    {
        Stats S3 = new Stats();
        S3._atk = S1._atk + S2._atk;
        S3._shd = S1._shd + S2._shd;
        S3._spd = S1._spd + S2._spd;
        S3._hp  = S1._hp  + S2._hp;
        return S3;
    }


}

