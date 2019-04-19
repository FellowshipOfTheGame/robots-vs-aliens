using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveProgressBar : MonoBehaviour
{
    public Slider slider;

    public void UpdateProgressBar(float progress)
    {
        slider.value = progress;
    }
}
