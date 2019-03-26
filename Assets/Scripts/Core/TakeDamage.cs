using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private Life LifeScript = null;

    private void Awake()
    {
        LifeScript = GetComponent<Life>();    
    }

    public void Damage(int damageDone)
    {
        LifeScript.DecreaseLife(damageDone);
    }

}
