using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRange : MonoBehaviour
{
    public Player Player;
    public float range;


    public bool IsNearPLayer()
    {
        if(Player != null)
        {
            if (Vector2.Distance(transform.position, Player.transform.position) <= range)
            {
                return true;
            }
        }
        return false;
       
    }

}
