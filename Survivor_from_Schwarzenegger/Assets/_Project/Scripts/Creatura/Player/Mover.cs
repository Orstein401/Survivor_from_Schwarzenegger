
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

class Mover
{
    public Vector2 _positionPlayer;

    //Contructor
    public Mover()
    { }

    //Getter
    public Vector2 GetPositionPlayer()
    {
        NormalizeVector();
        return _positionPlayer;
    }

    //Setter
    public void SetPositionPlayer()
    {
        _positionPlayer.x = Input.GetAxis("Horizontal");
        _positionPlayer.y = Input.GetAxis("Vertical");
    }


    public void NormalizeVector()
    {
        if (_positionPlayer.magnitude > 1) _positionPlayer = _positionPlayer.normalized;
    }

    public void Movement(Rigidbody2D rb, float speed)
    {
        GetPositionPlayer();
        rb.MovePosition(rb.position + _positionPlayer * (speed * Time.deltaTime));
    }
}
