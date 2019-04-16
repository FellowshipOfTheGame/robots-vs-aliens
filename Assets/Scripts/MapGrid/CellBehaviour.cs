using UnityEngine;
using UnityEngine.UI;

public class CellBehaviour : MonoBehaviour
{
    private static RobotSelector SelectorScript;
    private static ElectricityCounter ElectricityScript;

    [SerializeField] private Sprite OriginalSprite;
    [SerializeField] private Sprite HoveredSprite;

    private SpawnObject SpawnScript;
    private CellOccupation OccupationScript;
    private Image ImageComponent;

    void Awake()
    {
        SpawnScript = GetComponent<SpawnObject>();
        OccupationScript = GetComponent<CellOccupation>();
        ImageComponent = GetComponent<Image>();

        //Debug.Log("Interacting", gameObject);
        if (SelectorScript == null)
        {
            SelectorScript = FindObjectOfType<RobotSelector>();
            //if (SelectorScript != null) Debug.Log("Found it! -> " + SelectorScript.name, SelectorScript.gameObject);
        }
    }

    public void InteractWithCell()
    {
        if (ElectricityScript == null)
        {
            ElectricityScript = FindObjectOfType<ElectricityCounter>();
            //if (ElectricityScript != null) Debug.Log("Found it! -> " + ElectricityScript.name, ElectricityScript.gameObject);
        }

        //CASE 1 - PLACING A ROBOT
        if (OccupationScript.CheckCellOccupation() == false)
        {
            int index = SelectorScript.GetSelectedRobot();
            if (index >= 0)
            {
                SpawnScript.Spawn(index, Vector3.zero, Quaternion.identity, transform);
                SelectorScript.TriggerRobotCooldown();
                SelectorScript.DeselectRobot();
                OccupationScript.UpdateCellOccupation(true);

                ElectricityScript.SubtractElectricity(SelectorScript.GetSelectedCost());

                PointerExited();
            }
        }
    }

    public void PointerEntered()
    {
        if (SelectorScript.GetSelectedRobot() >= 0)
        {
            ImageComponent.sprite = HoveredSprite;
        }
    }

    public void PointerExited()
    {
        ImageComponent.sprite = OriginalSprite;
    }

}
