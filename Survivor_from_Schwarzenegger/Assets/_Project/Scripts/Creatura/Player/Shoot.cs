using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shooter(List<Weapon> weapon, BulletHero[] bullet, GameObject player)
    {
        Debug.Log(weapon.Count);
        for (int i = 0; i < weapon.Count; i++)
        {
            for (int j = 0; j < bullet.Length; j++)
            {
                if (weapon[i].GetNameAmmo() == (bullet[j].GetNameAmmo()))
                {
                    Debug.Log("Spara");
                    Spawn(player, bullet[i]);
                }
            }
            //bulletName = weapon[i].GetNameBulletHero();
            //BulletHero bulletHero = gameObject.GetComponent<bulletName>();
            //BulletHero bulletHeroPrefab = Instantiate(bulletHero);

        }

    }

    public void Spawn(GameObject player, BulletHero bullet)
    {

        BulletHero bulletHeroPrefab = Instantiate(bullet);
        bulletHeroPrefab.MovementBullet(gameObject.transform);
        Destroy(bulletHeroPrefab.gameObject, 2f);

    }
}
