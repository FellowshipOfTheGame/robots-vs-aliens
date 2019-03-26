using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] private int _life = 0;

    public State _state = State.alive;
    public enum State { dead, alive };

    public bool IsAlive()
    {
        return _state == State.alive ? true : false;
    }

    public int GetLife()
    {
        return _life;
    }

    public void SetLife(int value)
    {
        _life = value > 0 ? value : 0;
        if (_life <= 0)
            _state = State.dead;
    }

    public void DecreaseLife(int value)
    {
        if(_life >= 0)
        {
            _life -= value;
        }

        if(_life <= 0)
        {
            _state = State.dead;
        }
    }
}
