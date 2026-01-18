using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEnemy : MonoBehaviour
{
    public List<Enemy> enemies;
    public static int _limitGlobalEnemy;
    [SerializeField] private int _limitEnemy;
    private void Awake()
    {
        _limitGlobalEnemy = _limitEnemy;
    }
    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log(enemies.Count);
        }
        
    }
}
