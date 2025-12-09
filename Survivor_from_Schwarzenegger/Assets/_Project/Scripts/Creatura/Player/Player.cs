using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    Mover _mover = new Mover();
    Rigidbody2D _rb;
    // Start is called before the first frame update

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _mover.SetPositionPlayer();
    }

    private void FixedUpdate()
    {

        _mover.Movement(_rb, _speed);
    }
}
