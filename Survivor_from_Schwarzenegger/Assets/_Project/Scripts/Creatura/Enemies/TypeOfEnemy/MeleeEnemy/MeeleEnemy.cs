using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleEnemy : Enemy
{
    void Update()
    {

        if (knockBack.IsKnocked)
        {
            transform.position = Vector2.MoveTowards(transform.position, knockBack.knockTarget, knockBack.knockSpeed * Time.deltaTime);
        }
        else
        {
            if (IsTrigger.IsNearPLayer())
            {
                typeMove.Speed = stats._spd;
                typeMove.ChasePlayer();

            }
            else
            {
                typeMove.Speed = _walkingSpeed;
                typeMove.LogicMove();
            }
        }
        if (Vector2.Distance(transform.position, knockBack.knockTarget) < 0.05f)
        {
            knockBack.IsKnocked = false;
        }
    }
}
