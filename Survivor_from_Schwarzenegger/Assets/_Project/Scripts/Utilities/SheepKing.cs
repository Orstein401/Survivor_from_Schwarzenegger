using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepKing : MonoBehaviour
{
    [SerializeField] private Grid TreesGrid;

    private Animator _anim;
    
    void Awake()
    {
       TreesGrid = GetComponentInChildren<Grid>();
        _anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(TreesGrid.gameObject, 1.5f);
            _anim.SetBool("StartToPlay", true);
        }
    }
}
