using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    ManagerEnemy enemyManager;
    [SerializeField] List<Enemy> _listPrefabEnemy;
    [SerializeField] int limitEnemy;
    [SerializeField] Player player;
 

    [SerializeField] float rateOfSpawn;
    float lastTimeSpawn;

   
    public int currentNumEnemy;
    TriggerRange range;

    public List<Enemy> enemies;



    private void Awake()
    {
        enemyManager = FindAnyObjectByType<ManagerEnemy>();
        range = GetComponent<TriggerRange>();
        if (range == null)
        {
            range= gameObject.AddComponent<TriggerRange>();    
        }
        range.Player= player;
    }

    public void SpawingEnemy()
    {

        int indexRandomEnemy = Random.Range(0, _listPrefabEnemy.Count);
        Vector3 randomSpawnEnemy = transform.position;
        randomSpawnEnemy.x = transform.position.x + Random.Range(-10, 10);
        randomSpawnEnemy.y = transform.position.y + Random.Range(-10, 10);
        Enemy enemy = Instantiate(_listPrefabEnemy[indexRandomEnemy]);
        enemy.transform.position = randomSpawnEnemy;
        enemy.typeMove.SetUpPattern();
        enemy.setUpBirthPoint(this);
        currentNumEnemy += 1;

    }
    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
    }

    private void Update()
    {
        if (range.IsNearPLayer())
        {
            if (currentNumEnemy<=limitEnemy)
            {

                if (Time.time - lastTimeSpawn > rateOfSpawn)
                {
                    lastTimeSpawn = Time.time;
                    SpawingEnemy();
                }
            }
        }
        
    }
}
//    scrivo in chat
//Enemy e = Instantiate(prefab );
//    e.transform.position = new Vector3(qualcosa );
//    e.Setup();

//EPICODE
//epicode.com
//21:39
//può essere randomico
//o può essere sequenziale
//tipo il primo in (0,0,0)
//il secondo in (0,-1,0)
//il terzo in (0,.-2,0)
//esatto
//ora vado che così sento gli altri al volo
