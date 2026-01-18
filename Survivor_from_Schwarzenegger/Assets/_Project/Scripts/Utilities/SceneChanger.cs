using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private Animator _anim;
    public string Ivan2;

    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezePosition;

            collision.transform.position = transform.position;

            _anim.SetBool("IsActive" , true);

            Invoke("LoadIvan2", 1f);
        }
    }
    private void LoadIvan2()
    {
        SceneManager.LoadScene("Ivan2");
    }

}
