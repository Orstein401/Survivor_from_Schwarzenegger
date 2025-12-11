using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesDestroing : MonoBehaviour
{
    [SerializeField] private Grid Trees;
    private Animator _anim;

    void Awake()
    {
        Trees = GetComponentInChildren<Grid>();
        _anim = GetComponentInChildren<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(Trees.gameObject , 1.5f);
            _anim.SetBool("StartToPlay", true);
        }
    }
}
