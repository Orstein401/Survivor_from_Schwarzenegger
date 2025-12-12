using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLeftMove : MoveEnemy
{
    private Vector2[] Waypoints;
    private int currentPoint = 1;

    protected override void Awake()
    {
        base.Awake();
        SetUpPattern();
    }

    public override void SetUpPattern()
    {
        Waypoints = new Vector2[2];
        Waypoints[0] = StartPosition;
        Waypoints[1] = StartPosition + Vector2.right * LenghtPattern;
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
