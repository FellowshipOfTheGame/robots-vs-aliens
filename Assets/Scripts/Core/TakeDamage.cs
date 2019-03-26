using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private Life LifeScript = null;

    private void Awake()
    {
        LifeScript = GetComponent<Life>();    
    }

    //Damages the object with this component
    public void Damage(float damageDone)
    {
        damageDone = damageDone < 0 ?  -damageDone : damageDone; //Sets damage to positive
        LifeScript.DecreaseLife(damageDone);
    }

}
