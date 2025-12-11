using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class DropAmmo : MonoBehaviour
{
    [SerializeField] private Ammo _nameAmmo;
    [SerializeField] private Stats _bonusStats;
    [SerializeField] private float _rateOfFire;
    [SerializeField] private float _lifespan;
    private Weapon _weapon = new Weapon();
    // Start is called before the first frame update
    private void Awake()
    {
        _weapon.SetNameAmmo(_nameAmmo);
        _weapon.SetBonusStats(_bonusStats);
        _weapon.SetRateOfFire(_rateOfFire);
        _weapon.SetLifeSpan(_lifespan);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("CollideColPlayer");
            { Weapon.SetWeapon(_weapon); }

            gameObject.SetActive(false);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
