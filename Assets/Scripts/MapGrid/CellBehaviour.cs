using UnityEngine;

public class CellBehaviour : MonoBehaviour
{
    [SerializeField] private static RobotSelector SelectorScript;

    [SerializeField] private static ElectricityCounter ElectricityScript;

    private SpawnObject SpawnScript;
    private CellOccupation OccupationScript;

    void Awake()
    {
        SpawnScript = GetComponent<SpawnObject>();
        OccupationScript = GetComponent<CellOccupation>();
    }

    public void InteractWithCell()
    {
        //Debug.Log("Interacting", gameObject);
        if (SelectorScript == null)
        {
            SelectorScript = FindObjectOfType<RobotSelector>();
            //if (SelectorScript != null) Debug.Log("Found it! -> " + SelectorScript.name, SelectorScript.gameObject);
        }

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
                SelectorScript.DeselectRobot();
                OccupationScript.UpdateCellOccupation(true);

                ElectricityScript.SubtractElectricity(SelectorScript.GetSelectedCost());
            }
        }
    }
}
