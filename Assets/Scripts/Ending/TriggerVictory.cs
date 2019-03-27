using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVictory : MonoBehaviour
{
    [SerializeField] private GameObject VictoryText;
    [SerializeField] private GameObject MenuButton;

    public void Victory()
    {
        VictoryText.SetActive(true);
        MenuButton.SetActive(true);
    }
}
