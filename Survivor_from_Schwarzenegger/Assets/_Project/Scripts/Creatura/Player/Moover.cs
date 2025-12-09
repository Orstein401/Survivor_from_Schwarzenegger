
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

class Moover 
{
    private Vector2 _position;

    //Contructor
    public Moover()
    { }

    //Getter
    public Vector2 GetPosition()
    {
        return _position;
    }

    //Setter
    public void SetPosition()
    {
        _position.x = Input.GetAxis("Horizontal");
        _position.y = Input.GetAxis("Vertical");

        if (_position.magnitude > 1) _position = _position / _position.magnitude;

    }

    public void Moovment( Rigidbody2D rb , float speed)
    {
        rb.MovePosition(rb.position + _position * (speed * Time.deltaTime));
    }
}
