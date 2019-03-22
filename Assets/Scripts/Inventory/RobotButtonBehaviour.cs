using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotButtonBehaviour : MonoBehaviour
{
    [SerializeField] private static RobotSelector SelectorScript;

    private RobotCardCooldown CooldownScript;
    private ToggleButtonActivation ToggleButtonScript;

    [SerializeField] private int RobotIndex;

    private void Awake()
    {
        CooldownScript = GetComponent<RobotCardCooldown>();
        ToggleButtonScript = GetComponent<ToggleButtonActivation>();
    }

    public void SelectRobot()
    {
        if(SelectorScript == null)
        {
            SelectorScript = FindObjectOfType<RobotSelector>();
            if (SelectorScript != null) Debug.Log("Found it! -> " + SelectorScript.name, SelectorScript.gameObject);
        }
        SelectorScript.SelectRobot(RobotIndex);
    }
}
