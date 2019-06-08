using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RobotCardCooldown : MonoBehaviour
{
    private Image TransparentFill;
    private float FillAmount;

    //maybe not used
    private bool Available;

    private void Awake()
    {
        TransparentFill = transform.GetChild(1).GetComponent<Image>();
        FillAmount = 0;
        Available = true;
    }

    public void StartCooldown(float cooldownDelay)
    {
        print(cooldownDelay);
        Available = false;
        StartCoroutine(Cooldown(cooldownDelay));
    }

    public bool IsAvailable()
    {
        return Available;
    }

    private IEnumerator Cooldown(float cooldownDelay)
    {
        FillAmount = 1;
        //melhorar essa parte vvv
        while (FillAmount > 0)
        {
            TransparentFill.fillAmount = FillAmount;
            yield return null;
            FillAmount -= Time.deltaTime / cooldownDelay;
        }
        //melhorar essa parte ^^^
        FillAmount = 0;
        TransparentFill.fillAmount = FillAmount;
        Available = true;
    }
}
