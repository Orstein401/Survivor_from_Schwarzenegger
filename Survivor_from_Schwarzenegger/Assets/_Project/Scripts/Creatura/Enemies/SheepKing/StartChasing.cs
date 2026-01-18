using UnityEngine;

public class StartChasing : MonoBehaviour
{
    private SheepKing sheepKing;

    void Awake()
    {
        sheepKing = GetComponentInParent<SheepKing>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sheepKing.StartChasing(collision.transform);
            Destroy(gameObject);
        }
    }
}
