using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.VFX;

public class Shoot : MonoBehaviour
{
    private float gradi = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shooter(List<Weapon> weapon, BulletHero[] bullet, GameObject player, Vector2 directionPlayer, Camera camera)
    {
        //Ricerco la corrisponenza mediante nameammo tra il bullet da istanziare e l'arma
        //Se la trovo , verifico se posso sparare, in tal caso richiamo la funzione Spawn
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
                        Spawn(player, bullet[j], weapon[i].GetLifeSpan(), directionPlayer, camera);

                    }
                }
            }
            //bulletName = weapon[i].GetNameBulletHero();
            //BulletHero bulletHero = gameObject.GetComponent<bulletName>();
            //BulletHero bulletHeroPrefab = Instantiate(bulletHero);

        }

    }

    public void Spawn(GameObject player, BulletHero bullet, float lifespan, Vector2 directionPlayer, Camera camera)
    {
        Vector2 newDirection = new Vector2();
        //In base ai bullet definiti a priori i bullet saranno spawnati con determinate caratteristiche
        // Shotgun viene sparato in base al punto sullo schermo del mouse
        // Laser: avanti ed indietro
        // Spada: destra e sinistra
        // DannyDeVito 3 colpi che puntano su , in digonale a sx, in diagonale a dx
        // Gatling un colpo in senso orario
        // Libri: in altro a dx e poi va giu , mediante la forza di gravità
        switch (bullet.GetNameAmmo())
        {
            case Ammo.Shotgun:
                // Bullet che spara partendo dove sta il player fino a dove sta il mouse
                Vector3 mouseScreenPosition = Input.mousePosition; //Posizione del mouse sullo schermo ( ex 800 X 600 )
                mouseScreenPosition.z = -camera.transform.position.z; //distanza asse Z
                Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(mouseScreenPosition);//Vettore Posizione del mouse
                Vector3 toPosition = mouseWorldPosition - player.transform.position; //Vettore che va dal Player alla posizione del mouse
                newDirection.x = toPosition.x; newDirection.y = toPosition.y; //Passo il vettore che va dal player alla posizione del mouse alla 
                MenageSpawning(player, bullet, lifespan, newDirection);

                break;
            case Ammo.Laser:
                newDirection.y = 1;
                MenageSpawning(player, bullet, lifespan, newDirection);
                newDirection.y = -1;
                MenageSpawning(player, bullet, lifespan, newDirection);
                break;
            case Ammo.Spada:
                newDirection.x = 1;
                MenageSpawning(player, bullet, lifespan, newDirection);
                newDirection.x = -1;
                MenageSpawning(player, bullet, lifespan, newDirection);
                break;
            case Ammo.DannyDeVito:
                newDirection.x = 0; newDirection.y = 1;
                MenageSpawning(player, bullet, lifespan, newDirection);
                newDirection.x = 1; newDirection.y = 1;
                MenageSpawning(player, bullet, lifespan, newDirection);
                newDirection.x = -1; newDirection.y = 1;
                MenageSpawning(player, bullet, lifespan, newDirection);
                break;
            case Ammo.Gatling:
                //Gestione proiettili in senso orario
                if (gradi == -360) gradi = 0;
                //Conversione in radianti
                float radiant = gradi * Mathf.Deg2Rad;
                newDirection.x = (Mathf.Cos(radiant)) ;
                newDirection.y = (Mathf.Sin(radiant)) ;
                Debug.Log("Vettore Gatling " + newDirection);
                MenageSpawning(player, bullet, lifespan, newDirection);
                gradi--;
                break;
            case Ammo.Libri:
                newDirection.x = 1; newDirection.y = 1;
                MenageSpawning(player, bullet, lifespan, newDirection);
                break;
            default:
                break;
        }


    }

    public void MenageSpawning(GameObject player, BulletHero bullet, float lifespan, Vector2 directionPlayer)
    {
        BulletHero bulletHeroPrefab = Instantiate(bullet);   //Istanzio il prefab quindi creo una copia del bullet nella scena
        bulletHeroPrefab.transform.position = player.transform.position; //La posizione Iniziale dell'oggetto è il punto in cui è presente il player
        bulletHeroPrefab.MovementBullet(directionPlayer); //Richiamo la funzione movimento per spostarlo
        Destroy(bulletHeroPrefab.gameObject, lifespan);
    }

}
