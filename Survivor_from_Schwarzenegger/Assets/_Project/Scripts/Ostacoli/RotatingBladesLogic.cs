using System.Collections.Generic;
using UnityEngine;

public class RotatingBladesLogic : MonoBehaviour
{

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
        Vector2 distance = entity.transform.position - transform.position;
        Vector3 direction = new Vector3(distance.x, distance.y);
        entity.transform.position = entity.transform.position + direction * _knockbackForce;
    }
}
