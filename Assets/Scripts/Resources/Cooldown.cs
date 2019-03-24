using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown : MonoBehaviour
{
    [SerializeField] private float cooldownTime;
    private bool isCooldownDone;

    public bool IsCooldownDone{
        get{return isCooldownDone;}
        set{isCooldownDone = value;}
    }

    private float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = cooldownTime;
        isCooldownDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isCooldownDone){
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0){
                isCooldownDone = true;
            }
        }
    }

    public void ResetCooldown(){
        isCooldownDone = false;
        timeLeft = cooldownTime;
    }
}
