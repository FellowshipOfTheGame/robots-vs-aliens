using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSelector : MonoBehaviour
{
    private int SelectedIndex = 0;
    private int SelectedCost = 0;

    public void SelectRobot(int index, int cost)
    {
        SelectedIndex = index;
        SelectedCost = cost;
    }

    public void DeselectRobot()
    {
        SelectedIndex = -1;
    }

    public int GetSelectedRobot()
    {
        return SelectedIndex;
    }

    public int GetSelectedCost()
    {
        return SelectedCost;
    }
}
