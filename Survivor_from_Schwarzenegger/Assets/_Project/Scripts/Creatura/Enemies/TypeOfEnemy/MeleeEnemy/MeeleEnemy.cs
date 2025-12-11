using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleEnemy : Enemy
{
    void Update()
    {

        if (typeMove.IsKnocked)
        {
            transform.position = Vector2.MoveTowards(transform.position, typeMove.knockTarget, typeMove.knockSpeed * Time.deltaTime);
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
        if (Vector2.Distance(transform.position, typeMove.knockTarget) < 0.05f)
        {
            typeMove.IsKnocked = false;
        }
    }
}
