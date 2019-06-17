using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private ParticleSystem particles = null;
    private Life LifeScript = null;

    private void Awake()
    {
        particles = GetComponent<ParticleSystem>();
        LifeScript = GetComponent<Life>();    
    }

    //Damages the object with this component
    public void Damage(float damageDone)
    {
        particles?.Play();
        damageDone = damageDone < 0 ?  -damageDone : damageDone; //Sets damage to positive
        LifeScript.DecreaseLife(damageDone);
    }

}
