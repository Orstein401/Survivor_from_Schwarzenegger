using System.Collections.Generic;
using UnityEngine;

public class TrapLogic : MonoBehaviour
{
    /*
    TO DO:
    [DONE] IMPLEMENTARE LA FUNZIONE PER TRASFERIRE I DANNI ALL'OGGETTO IN COLLISIONE (PLAYER O ENEMY)
    [DONE IVAN] CREARE UN PREFAB PER LE TRAPPOLE O DEI TILE CON GLI ASSET A DISPOSIZIONE (DA SEGUIRE CON IVAN)
    - CREARE AUDIO (DA SEGUIRE CON CHI SI OCCUPA DELL'AUDIO)
    - TESTARE CON PIU' ENEMY NEL TRIGGER E VEDERE CHE SUCCEDE
     */

    [SerializeField] private bool _isActive;
    [SerializeField] private int _entitiesInRangeCount;
    [SerializeField] private int _damage = 20;
    [SerializeField] private float _damageRate = 1f;

    private SpikeAnimation _anim;
    private float _lastTimeDamaged;
    private List<GameObject> _entitiesInRange = new List<GameObject>();

    private void Awake()
    {
        _anim = GetComponent<SpikeAnimation>();
    }

    private void Update()
    {
<<<<<<< Updated upstream
        if (isActive)
=======
        if (_isActive && (Time.time - _lastTimeDamaged >= _damageRate))
>>>>>>> Stashed changes
        {
            foreach (GameObject entity in _entitiesInRange) DamageEntity(entity);
        }
    }

    // Rileva se il Player e/o un Enemy finiscono nel raggio d'azione della trappola per attivarla
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
<<<<<<< Updated upstream
            isActive = true;
            entitiesInRange++;
=======
            Invoke("ActivateTrap", 2f);
>>>>>>> Stashed changes
        }
    }

    // Rileva se il Player e/o tutti gli Enemy sono usciti dal raggio d'azione della trappola per disattivarla
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
<<<<<<< Updated upstream
            entitiesInRange--;
            isActive = entitiesInRange <= 0 ? false : true; // Se non escono tutte le entita' dal trigger, lascio la trappola attiva
=======
            _entitiesInRange.Remove(collision.gameObject);
            _entitiesInRangeCount--;
            _isActive = _entitiesInRangeCount <= 0 ? false : true; // Se non escono tutte le entita' dal trigger, lascio la trappola attiva
            if (!_isActive) _anim.SetIsActiveParam(_isActive);
>>>>>>> Stashed changes
        }
    }

    private void ActivateTrap(Collider2D collision)
    {
        _isActive = true;
        _entitiesInRangeCount++;
        _anim.SetIsActiveParam(_isActive);
        _entitiesInRange.Add(collision.gameObject);
        DamageEntity(collision.gameObject);
        _lastTimeDamaged = Time.time;
    }

    private void DamageEntity(GameObject entity)
    {
        LifeController lifeController = entity.GetComponent<LifeController>();
        lifeController.TakeDamage(_damage);
    }

}
