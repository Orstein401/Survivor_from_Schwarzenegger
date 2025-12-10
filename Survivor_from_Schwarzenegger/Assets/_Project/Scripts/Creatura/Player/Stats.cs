using System;
using System.Security.Cryptography;
using UnityEngine;

[Serializable]

public struct Stats
{

    [SerializeField] public int atk;
    [SerializeField] public int shd;
    [SerializeField] public int spd;

    //Construct
    public Stats(int atk, int def, int spd )
    {
        this.atk = atk;
        this.shd = def;
        this.spd = spd;
    }

    //Functionality
    public static Stats Sum(Stats S1, Stats S2)
    {
        Stats S3 = new Stats();
        S3.atk = S1.atk + S2.atk;
        S3.shd = S1.shd + S2.shd;
        S3.spd = S1.spd + S2.spd;
        return S3;
    }


}

