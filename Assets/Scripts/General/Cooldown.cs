using UnityEngine;

public class Cooldown : MonoBehaviour
{
    [SerializeField] private float cooldownTime = 0;
    public delegate void CooldownDelegate();
    public CooldownDelegate OnCooldownEnded;

    private bool CooldownRunning = false;

    //private bool isCooldownDone = false;

    /*public bool IsCooldownDone{
        get{return isCooldownDone;}
        set{isCooldownDone = value;}
    }*/

    public float CooldownTime{
        get{return cooldownTime;}
        set{cooldownTime = value;}
    }

    private float timeLeft;

    void Awake()
    {
        ResetCooldown();
    }

    void Update()
    {
        if(CooldownRunning){
            timeLeft -= Time.deltaTime;
            if(timeLeft <= 0){
                CooldownRunning = false;
                OnCooldownEnded.Invoke();
            }
        }
    }

    public void ResetCooldown(){
        CooldownRunning = true;
        timeLeft = cooldownTime;
    }
}
