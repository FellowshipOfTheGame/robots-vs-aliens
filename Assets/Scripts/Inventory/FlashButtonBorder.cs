using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlashButtonBorder : MonoBehaviour
{
    private Image thisImage = null;
    private bool activated = false;
    [SerializeField] private float flashRate = 0.5f;

    private void Awake()
    {
        thisImage = transform.Find("BorderImage").GetComponent<Image>();
    }

    public void ToggleActive(bool activeState)
    {
        activated = activeState;
        if (activated)
        {
            thisImage.enabled = true;
            StartCoroutine(FlashSprite(flashRate));
        }
        else
        {
            thisImage.enabled = false;
            StopAllCoroutines();
        }
    }

    IEnumerator FlashSprite(float time)
    {
        yield return new WaitForSeconds(time);
        thisImage.enabled = !thisImage.enabled;
        StartCoroutine(FlashSprite(time));
    }
}
