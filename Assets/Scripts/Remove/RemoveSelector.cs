using UnityEngine;

public class RemoveSelector : MonoBehaviour
{
    //private int RemovedIndex = 0;
    //private int RemovedCost = 0;
    private bool RemoveSelected = false;
    private Animator AnimatorComponent = null;

    [SerializeField] private MouseEvents MouseScript = null;

    private void Awake()
    {
        AnimatorComponent = GetComponent<Animator>();
        if (MouseScript == null) MouseScript = FindObjectOfType<MouseEvents>();
        MouseScript.MouseRightClick += SelectedOff;
    }

    public bool isSelected()
    {
        return RemoveSelected;
    }

    public void SelectedOn()
    {
        if (!RemoveSelected) AnimatorComponent.SetTrigger("On");
        RemoveSelected = true;
    }

    public void SelectedOff()
    {
        if(RemoveSelected) AnimatorComponent.SetTrigger("Off");
        RemoveSelected = false;
    }

    public void SwitchSelected()
    {
        RemoveSelected = !RemoveSelected;
        if (RemoveSelected)
        {
            SFXController.PlayClip("SelectButton");
            AnimatorComponent.SetTrigger("On");
        }
        else{
            SFXController.PlayClip("BackButton");
            AnimatorComponent.SetTrigger("Off");
        }
    }

}
