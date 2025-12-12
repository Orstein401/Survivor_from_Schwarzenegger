using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CobwebLogic : MonoBehaviour
{
    [SerializeField] private int _slowDownFactor = 2; // Fattore che determina quanto viene rallentato il Player

    // Il Player rallenta una volta entrato nel collider della ragnatela
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player._baseStats._spd /= _slowDownFactor;
        }
    }

    // Il Player torna alla velocita' precedente una volta uscito dal range
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player._baseStats._spd *= _slowDownFactor;
        }
    }
}
