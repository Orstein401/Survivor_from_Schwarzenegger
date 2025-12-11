using System.Collections.Generic;
using UnityEngine;

public class RotatingBladesLogic : MonoBehaviour
{
    /*
    TO DO:
    [DONE] IMPLEMENTARE LA FUNZIONE PER TRASFERIRE I DANNI ALL'OGGETTO IN COLLISIONE (PLAYER O ENEMY)
    [DONE IVAN] CREARE UN PREFAB PER LE TRAPPOLE O DEI TILE CON GLI ASSET A DISPOSIZIONE (DA SEGUIRE CON IVAN)
    - CREARE AUDIO (DA SEGUIRE CON CHI SI OCCUPA DELL'AUDIO)
    - TESTARE CON PIU' ENEMY NEL TRIGGER E VEDERE CHE SUCCEDE
     */

    [SerializeField] private int _damage = 20;
    [SerializeField] private float _damageRate = 1f;
    [SerializeField] private float _knockbackForce = 1f;

    private float _lastTimeDamaged;
    private List<GameObject> _entitiesInRange = new List<GameObject>();

    private void Start()
    {
        _lastTimeDamaged = Time.time;
    }

    private void Update()
    {
        if (Time.time - _lastTimeDamaged >= _damageRate)
        {
            foreach (GameObject entity in _entitiesInRange)
            {
                DamageEntity(entity);
                Knockback(entity);
            }
        }
    }

    // Rileva se il Player e/o un Enemy finiscono nel raggio d'azione della trappola per attivarla
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            _entitiesInRange.Add(collision.gameObject);
        }
    }

    // Rileva se il Player e/o tutti gli Enemy sono usciti dal raggio d'azione della trappola per disattivarla
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            _entitiesInRange.Remove(collision.gameObject);
        }
    }

    private void DamageEntity(GameObject entity)
    {
        LifeController lifeController = entity.GetComponent<LifeController>();
        lifeController.TakeDamage(_damage);
        _lastTimeDamaged = Time.time;
    }

    private void Knockback(GameObject entity)
    {
        Vector3 direction = new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), entity.transform.position.z);
        Rigidbody2D rb = entity.GetComponent<Rigidbody2D>();
        entity.transform.position = entity.transform.position + direction * _knockbackForce;
    }
}
