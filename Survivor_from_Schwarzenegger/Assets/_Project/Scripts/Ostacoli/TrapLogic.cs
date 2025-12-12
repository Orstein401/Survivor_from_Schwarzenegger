using System.Collections.Generic;
using UnityEngine;

public class TrapLogic : MonoBehaviour
{

    [SerializeField] private int _damage = 20; // Danno per tick della trappola
    [SerializeField] private float _damageRate = 1f; // Durata tick di danno della trappola
    [SerializeField] private float _trapDelay = 1f; // Dopo quanto tempo parte l'animazione della trappola
    [SerializeField] private float _knockbackForce = 1f; // Forza di knockback della trappola

    private SpikeAnimation _anim;
    private bool _isActive;
    private int _entitiesInRangeCount;
    private float _lastTimeDamaged;
    private List<GameObject> _entitiesInRange = new List<GameObject>(); // Lista contenente tutte le entita' nel range della trappola

    private void Awake()
    {
        _anim = GetComponent<SpikeAnimation>();
    }

    private void Update()
    {
        // Se la trappola e' attiva, faccio danno a tutte le entita' nella lista
        if (_isActive && (Time.time - _lastTimeDamaged >= _damageRate))
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
            Invoke("StartAnimation", _trapDelay); // Faccio partire l'animazione con il delay
            _entitiesInRange.Add(collision.gameObject);
            _entitiesInRangeCount++;
            _isActive = true;
            _lastTimeDamaged = Time.time;
        }
    }

    // Rileva se il Player e/o tutti gli Enemy sono usciti dal raggio d'azione della trappola per disattivarla
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            _entitiesInRange.Remove(collision.gameObject);
            _entitiesInRangeCount--;
            _isActive = _entitiesInRangeCount <= 0 ? false : true; // Se non escono tutte le entita' dal trigger, lascio la trappola attiva
            if (!_isActive) Invoke("StopAnimation", _trapDelay); // Fermo l'animazione con delay per evitare di farla andare in loop all'infinito
        }
    }

    private void StartAnimation()
    {
        _anim.SetIsActiveParam(true);
    }

    private void StopAnimation()
    {
        _anim.SetIsActiveParam(false);
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
