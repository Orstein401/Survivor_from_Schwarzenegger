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

    public void Shooter(List<Weapon> weapon, BulletHero[] bullet, GameObject player, Vector2 ShootDirection)
    {
        Debug.Log("Numero di Armi" + weapon.Count);
        for (int i = 0; i < weapon.Count; i++)
        {

            for (int j = 0; j < bullet.Length; j++)
            {
                if (weapon[i].GetNameAmmo() == (bullet[j].GetNameAmmo()))
                {
                    Debug.Log("Nome Arma " + weapon[i].GetNameAmmo());
                    Debug.Log("Nome Bullet Arma " + bullet[j].GetNameAmmo());

                    if (weapon[i].CanIShoot() == true)
                    {
                        Debug.Log("Spara" + weapon[i].GetNameAmmo());
                        Spawn(player, bullet[j], weapon[i].GetLifeSpan(),ShootDirection);

                    }
                }
            }
            //bulletName = weapon[i].GetNameBulletHero();
            //BulletHero bulletHero = gameObject.GetComponent<bulletName>();
            //BulletHero bulletHeroPrefab = Instantiate(bulletHero);

        }

    }

    public void Spawn(GameObject player, BulletHero bullet, float lifespan, Vector2 ShootDirection)
    {
        
        BulletHero bulletHeroPrefab = Instantiate(bullet);   //Istanzio il prefab quindi creo una copia del bullet nella scena
        bulletHeroPrefab.transform.position = player.transform.position; //La posizione Iniziale dell'oggetto è il punto in cui è presente il player
        bulletHeroPrefab.MovementBullet(ShootDirection); //Richiamo la funzione movimento per spostarlo
        Destroy(bulletHeroPrefab.gameObject, lifespan);

    }
}
