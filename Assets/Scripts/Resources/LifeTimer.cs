using UnityEngine;

public class LifeTimer : MonoBehaviour
{
    [SerializeField] private float TimeUntilDestroyed = 0;
    private float TimeElapsed = 0;
    private DestroyObject DestroyScript = null;

    [SerializeField] private bool StartOnAwake = false;
    private bool TimerCounting = false;

    private void Awake()
    {
        DestroyScript = GetComponent<DestroyObject>();
        if (StartOnAwake)
        {
            StartTimer();
        }
    }

    public void StartTimer()
    {
        TimerCounting = true;
    }

    public void ResetTimer()
    {
        TimeElapsed = 0;
    }

    public void TogglePauseTimer()
    {
        TimerCounting = !TimerCounting;
    }

    private void Update()
    {
        if (TimerCounting)
        {
            if (TimeElapsed >= TimeUntilDestroyed)
            {
                DestroyScript.Destroy();
            }
            else
            {
                TimeElapsed += Time.deltaTime;
            }
        }
    }

}
