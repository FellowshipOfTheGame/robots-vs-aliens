using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotCardCooldown : MonoBehaviour
{
    [SerializeField] private Image TransparentFill;
    private float FillAmount;

    //maybe not used
    private bool Available;

    private void Awake()
    {
        TransparentFill = transform.GetChild(0).GetComponent<Image>();
        FillAmount = 0;
        Available = true;
    }

    public void StartCooldown(float cooldownDelay)
    {
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
        while(FillAmount > 0)
        {
            TransparentFill.fillAmount = FillAmount;
            yield return null;
            FillAmount -= 1.0f / cooldownDelay;
        }
        FillAmount = 0;
        Available = true;
    }
}
