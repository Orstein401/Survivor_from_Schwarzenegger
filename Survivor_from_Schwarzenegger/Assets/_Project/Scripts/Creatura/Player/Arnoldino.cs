using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Arnoldino
{
    [SerializeField] int _hp;

    LifeController lifeController;

    public Arnoldino(int hp)
    {
        lifeController.SetHp(hp);
    }




}
