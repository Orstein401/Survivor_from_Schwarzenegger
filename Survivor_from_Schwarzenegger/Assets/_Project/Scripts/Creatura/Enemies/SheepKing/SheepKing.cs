using System.Collections;
using UnityEngine;

public class SheepKing : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float chaseDelay = 1f;

    private Animator _anim;
    private Rigidbody2D _rb;
    private Transform _player;

    private bool isChasing = false;
    private bool chaseStarted = false;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!isChasing || _player == null)
        {
            _rb.velocity = Vector2.zero;
            return;
        }

        Vector2 direction = (_player.position - transform.position).normalized;
        _rb.velocity = direction * _speed;

        _anim.SetFloat("MoveX", direction.x);
        _anim.SetFloat("MoveY", direction.y);

    }

    // Chiamato dal trigger
    public void StartChasing(Transform player)
    {
        if (chaseStarted) return;

        chaseStarted = true;
        _player = player;

        _anim.SetBool("StartToPlay", true);
        _anim.SetBool("InRange", true);

        //delay prima dell'inseguimento
        StartCoroutine(ChaseAfterDelay());
    }

    private IEnumerator ChaseAfterDelay()
    {
        yield return new WaitForSeconds(chaseDelay);

        isChasing = true;
    }
}


