using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int _life = 0;
    public State _state = State.alive;

    public enum State { dead, alive };

    public bool isAlive()
    {
        return _state == State.alive ? true : false;
    }

    public int getLife()
    {
        return _life;
    }

    public void setLife(int value)
    {
        _life = value > 0 ? value : 0;
        if (_life <= 0)
            _state = State.dead;
    }

}
