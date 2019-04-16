using UnityEngine;
using UnityEngine.UI;

public class RobotButtonBehaviour : MonoBehaviour
{
    private static RobotSelector SelectorScript;

    private RobotCardCooldown CooldownScript;
    private ToggleButtonActivation ToggleButtonScript;
    private Image ImageComponent;

    [SerializeField] private int RobotIndex;
    [SerializeField] private int RobotCost = 0;
    [SerializeField] private static ElectricityCounter ElectricityCounterScript;

    [SerializeField] private Sprite OriginalSprite;
    [SerializeField] private Sprite PressedSprite;

    private void Awake()
    {
        CooldownScript = GetComponent<RobotCardCooldown>();

        ToggleButtonScript = GetComponent<ToggleButtonActivation>();

        ImageComponent = GetComponent<Image>();

        if (SelectorScript == null)
        {
            SelectorScript = FindObjectOfType<RobotSelector>();
        }
        if (ElectricityCounterScript == null)
        {
            ElectricityCounterScript = FindObjectOfType<ElectricityCounter>();
        }
    }
    public void SelectRobot()
    {
        if (CooldownScript.IsAvailable())
        {
            if (RobotCost <= ElectricityCounterScript.Electricity)
            {
                SelectorScript.SelectRobot(RobotIndex, RobotCost, this);
                MarkButtonSelected();
            }
            else
            {
                //NOT ENOUGH MONEY
                Debug.Log("Not enough energy!", gameObject);
                SelectorScript.DeselectRobot();
            }
        }
        else
        {
            //NOT READY YET
            Debug.Log("Cooldown not finished yet!", gameObject);
            SelectorScript.DeselectRobot();
        }
    }

    public void MarkButtonSelected()
    {
        ImageComponent.sprite = PressedSprite;
    }

    public void MarkButtonDeselected()
    {
        ImageComponent.sprite = OriginalSprite;
    }
}
