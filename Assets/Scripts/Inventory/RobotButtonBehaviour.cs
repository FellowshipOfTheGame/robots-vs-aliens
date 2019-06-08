using UnityEngine;
using UnityEngine.UI;

public class RobotButtonBehaviour : MonoBehaviour
{
    private static RobotSelector SelectorScript;

    private RobotCardCooldown CooldownScript;
    private ToggleButtonActivation ToggleButtonScript;
    private FlashButtonBorder BorderScript;
    //private Image ImageComponent;

    [SerializeField] private int RobotIndex = 0;
    [SerializeField] private int RobotCost = 0;
    [SerializeField] private static ElectricityCounter ElectricityCounterScript = null;
    [SerializeField] private float CooldownTime = 0;

    //[SerializeField] private Sprite OriginalSprite = null;
    //[SerializeField] private Sprite PressedSprite = null;

    private void Awake()
    {
        CooldownScript = GetComponent<RobotCardCooldown>();

        ToggleButtonScript = GetComponent<ToggleButtonActivation>();

        BorderScript = GetComponent<FlashButtonBorder>();

        //ImageComponent = GetComponent<Image>();

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
                //FLASH A NEGATIVE IMAGE ONCE
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
        BorderScript.ToggleActive(true);
        //ImageComponent.sprite = PressedSprite;
        SFXController.PlayClip("SelectButton");
    }

    public void MarkButtonDeselected()
    {
        BorderScript.ToggleActive(false);
        //ImageComponent.sprite = OriginalSprite;
    }

    public void StartCooldown()
    {
        print(CooldownTime);
        CooldownScript.StartCooldown(CooldownTime);
    }
}
