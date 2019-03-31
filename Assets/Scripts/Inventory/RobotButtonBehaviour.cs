using UnityEngine;
public class RobotButtonBehaviour : MonoBehaviour

{

    [SerializeField] private static RobotSelector SelectorScript; private RobotCardCooldown CooldownScript;

    private ToggleButtonActivation ToggleButtonScript;[SerializeField] private int RobotIndex;

    [SerializeField] private int RobotCost = 0;[SerializeField] private static ElectricityCounter ElectricityCounterScript; private void Awake()
    {
        CooldownScript = GetComponent<RobotCardCooldown>();

        ToggleButtonScript = GetComponent<ToggleButtonActivation>();
    }
    public void SelectRobot()
    {
        if (SelectorScript == null)
        {
            SelectorScript = FindObjectOfType<RobotSelector>();
        }
        if (ElectricityCounterScript == null)
        {
            ElectricityCounterScript = FindObjectOfType<ElectricityCounter>();
        }
        if (CooldownScript.IsAvailable() && (RobotCost <= ElectricityCounterScript.Electricity))
        {
            SelectorScript.SelectRobot(RobotIndex, RobotCost);
        }
        else
        {
            SelectorScript.DeselectRobot();
        }
    }
}
