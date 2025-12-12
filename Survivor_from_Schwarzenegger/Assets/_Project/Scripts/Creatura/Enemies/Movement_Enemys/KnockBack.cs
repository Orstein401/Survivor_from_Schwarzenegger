using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    //variabili per gestire la spinta subita dal proiettiele nemico(Player)
    protected bool isKnocked = false;
    public float knockSpeed;
    public Vector2 knockTarget;

    public bool IsKnocked
    {
        get { return isKnocked; }
        set { isKnocked = value; }
    }
    public void StartKnockback(Vector2 dir, float force)
    {
        knockTarget = (Vector2)transform.position + dir*force;
        knockSpeed = force;
        isKnocked = true;
    }
}
