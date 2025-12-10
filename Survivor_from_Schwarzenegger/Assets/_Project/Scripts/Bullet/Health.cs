using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField] private int _hp;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            LifeController LifePlayer = GetComponent<LifeController>();

            LifePlayer.AddHp(_hp);
        }
    }
}
