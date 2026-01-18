using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagMoveEnemy : MoveEnemy
{
    private Vector2[] Waypoints;
    private int currentPoint = 1;

    protected override void Awake()
    {
        base.Awake();
        
    }

    public override void SetUpPattern()
    {
        base.SetUpPattern();
        Waypoints = new Vector2[5];
        Waypoints[0] = StartPosition;
        Waypoints[1] = StartPosition + new Vector2(LenghtPattern, 1f);
        Waypoints[2] = StartPosition + Vector2.up * 2f;
        Waypoints[3] = StartPosition + new Vector2(LenghtPattern, 3f);
        Waypoints[4] = StartPosition + Vector2.down * -LenghtPattern;
    }
    public override void LogicMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, Waypoints[currentPoint], Speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, Waypoints[currentPoint]) < 0.05f)
        {
            currentPoint++;
            if (currentPoint >= Waypoints.Length)
            {
                currentPoint = 0;
            }
        }

    }
}
