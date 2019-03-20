using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellOccupation : MonoBehaviour
{
    private bool isOccupied;

    void Awake()
    {
        isOccupied = false;
    }

    public bool CheckCellOccupation()
    {
        return isOccupied;
    }   

    public void UpdateCellOccupation(bool occupation)
    {
        isOccupied = occupation;
    }
}
