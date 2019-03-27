using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSelector : MonoBehaviour
{
    private int SelectedIndex;

    public void SelectRobot(int index)
    {
        SelectedIndex = index;
    }

    public void DeselectRobot()
    {
        SelectedIndex = -1;
    }

    public int GetSelectedRobot()
    {
        return SelectedIndex;
    }
}
