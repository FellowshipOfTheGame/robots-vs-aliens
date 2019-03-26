using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float _speed = 0;
    public Vector2 _direction = Vector2.zero;
    public bool _move = false;

    private void FixedUpdate()
    {
        if(_move == true)
            Move();
    }

    private void Move()
    {
        transform.Translate(_direction.normalized * _speed * Time.deltaTime, Space.World);
    }

    public void StartMovement()
    {
        _move = true;
    }

    public void setParameters(float speed, Vector2 direction)
    {
        _speed = speed;
        _direction = direction;
    }
}
