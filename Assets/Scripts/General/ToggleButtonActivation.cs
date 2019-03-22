using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonActivation : MonoBehaviour
{
    private Button ThisButton;

    private void Awake()
    {
        ThisButton = GetComponent<Button>();
    }

    public void ToggleActivation()
    {
        ThisButton.interactable = !ThisButton.interactable;
    }
}
