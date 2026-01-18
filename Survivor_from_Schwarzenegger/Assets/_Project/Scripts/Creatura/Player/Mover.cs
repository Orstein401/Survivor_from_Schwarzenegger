
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

class Mover
{
    public Vector2 _positionPlayer;
    private Vector2 _lastDirectionValorize;
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
        if (_positionPlayer.x == 0) _positionPlayer.x = _lastDirectionValorize.x;
        else _lastDirectionValorize.x = _positionPlayer.x;
        if (_positionPlayer.y == 0) _positionPlayer.y = _lastDirectionValorize.y;
        else _lastDirectionValorize.y = _positionPlayer.y;
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
