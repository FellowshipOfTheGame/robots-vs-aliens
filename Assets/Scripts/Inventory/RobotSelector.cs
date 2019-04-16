using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSelector : MonoBehaviour
{
    private int SelectedIndex = 0;
    private int SelectedCost = 0;
    private RobotButtonBehaviour SelectedButton = null;

    private void Start()
    {
        DeselectRobot();
    }

    public void SelectRobot(int index, int cost, RobotButtonBehaviour button)
    {
        SelectedIndex = index;
        SelectedCost = cost;
        SelectedButton?.MarkButtonDeselected();
        SelectedButton = button;
    }

    public void DeselectRobot()
    {
        SelectedIndex = -1;
        SelectedCost = 0;
        SelectedButton?.MarkButtonDeselected();
        SelectedButton = null;
    }

    public int GetSelectedRobot()
    {
        return SelectedIndex;
    }

    public int GetSelectedCost()
    {
        return SelectedCost;
    }

    public RobotButtonBehaviour GetSelectedButton()
    {
        return SelectedButton;
    }
}
