using UnityEngine;

public class RemoveSelector : MonoBehaviour
{
    //private int RemovedIndex = 0;
    //private int RemovedCost = 0;
    private bool RemoveSelected = false;

    [SerializeField] private MouseEvents MouseScript;

    private void Awake()
    {
        if (MouseScript == null) MouseScript = FindObjectOfType<MouseEvents>();
        MouseScript.MouseRightClick += SelectedOff;
    }

    public bool isSelected()
    {
        return RemoveSelected;
    }

    public void SelectedOn()
    {
        RemoveSelected = true;
    }

    public void SelectedOff()
    {
        RemoveSelected = false;
    }

    public void SwitchSelected()
    {
        RemoveSelected = !RemoveSelected;
    }

}
