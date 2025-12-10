using UnityEngine;

public class TrapLogic : MonoBehaviour
{
    /*
    TO DO:
    - IMPLEMENTARE LA FUNZIONE PER TRASFERIRE I DANNI ALL'OGGETTO IN COLLISIONE (PLAYER O ENEMY)
    - CREARE UN PREFAB PER LE TRAPPOLE O DEI TILE CON GLI ASSET A DISPOSIZIONE (DA SEGUIRE CON IVAN)
    - CREARE L'ANIMAZIONE DI ATTIVAZIONE E DISATTIVAZIONE CON EVENTUALE AUDIO (DA SEGUIRE CON CHI SI OCCUPA DELL'AUDIO)
    - TESTARE CON PIU' ENEMY NEL TRIGGER E VEDERE CHE SUCCEDE
     */

    [SerializeField] private bool _isActive;
    [SerializeField] private int _entitiesInRange;
    [SerializeField] private int _damage;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (_isActive)
        {
            Debug.Log("Trappola attiva");
        }
    }

    // Rileva se il Player e/o un Enemy finiscono nel raggio d'azione della trappola per attivarla
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            _isActive = true;
            _entitiesInRange++;
        }
    }

    // Rileva se il Player e/o tutti gli Enemy sono usciti dal raggio d'azione della trappola per disattivarla
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            _entitiesInRange--;
            _isActive = _entitiesInRange <= 0 ? false : true; // Se non escono tutte le entita' dal trigger, lascio la trappola attiva
        }
    }

}
