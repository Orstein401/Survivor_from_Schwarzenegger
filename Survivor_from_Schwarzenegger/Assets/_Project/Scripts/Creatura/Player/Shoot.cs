using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void Shooter(List<Weapon> weapon, BulletHero[] bullet)
    {
        string bulletName;
        for (int i = 0; i < weapon.Count; i++)
        {
            //bulletName = weapon[i].GetNameBulletHero();
            //BulletHero bulletHero = gameObject.GetComponent<bulletName>();
            //BulletHero bulletHeroPrefab = Instantiate(bulletHero);

        }

    }
}
