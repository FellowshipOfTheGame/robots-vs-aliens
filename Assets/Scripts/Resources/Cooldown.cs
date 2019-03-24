using UnityEngine;

public class Cooldown : MonoBehaviour
{
    [SerializeField] private float cooldownTime = 0;
    private bool isCooldownDone = false;

    public bool IsCooldownDone{
        get{return isCooldownDone;}
        set{isCooldownDone = value;}
    }

    private float timeLeft;

    void Awake()
    {
        isCooldownDone = false;
        timeLeft = cooldownTime;
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
