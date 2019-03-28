using UnityEngine;

public class Cooldown : MonoBehaviour
{
    [SerializeField] private float cooldownTime = 0;
    private bool isCooldownDone = false;

    public bool IsCooldownDone{
        get{return isCooldownDone;}
        set{isCooldownDone = value;}
    }

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
        if(!isCooldownDone){
            timeLeft -= Time.deltaTime;
            if(timeLeft <= 0){
                isCooldownDone = true;
            }
        }
    }

    public void ResetCooldown(){
        isCooldownDone = false;
        timeLeft = cooldownTime;
    }
}
