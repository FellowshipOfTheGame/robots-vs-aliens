using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] private float _life = 0f;
    [SerializeField] private float _max_life = 0f;

    public State _state = State.alive;
    public enum State { dead, alive };

    public delegate void LifeDelegate();
    public LifeDelegate OnDeath;


    public bool isAlive()
    {
        return _state == State.alive ? true : false;
    }

    public float getLife()
    {
        return _life;
    }

    public void DecreaseLife(float value)
    {
        _life = (_life - value) > 0 ? _life-value : 0;
        if (_life <= 0)
            OnDeath.Invoke();//_state = State.dead;
    }

    public void IncreaseLife(float value)
    {
        if(_state == State.alive)
        {
            _life = (_life + value) <= _max_life ? _life + value : _max_life;
        }
    }

    public void Revive()
    {
        _state = State.alive;
    }

    private void Update()
    {
        //if (!isAlive())
            //OnDeath.invoke(); //uso do delegate para morte
    }

}
