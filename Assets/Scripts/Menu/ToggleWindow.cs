using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleWindow : MonoBehaviour
{
    private static GameObject CurrentWindow = null;
    private GameObject OpenedWindow = null;

    public void SetActiveWindow(GameObject newWindow){
        CurrentWindow = newWindow;
    }

    public void ChangeActiveWindow(GameObject newWindow){
        SFXController.PlayClip("SelectButton");
        CurrentWindow?.SetActive(false);
        newWindow?.SetActive(true);
        CurrentWindow = newWindow;
    }

    public void OpenWindow(GameObject newWindow){
        newWindow?.SetActive(true);
        OpenedWindow = newWindow;
    }

    public void CloseWindow(GameObject openedWindow)
    {
        OpenedWindow = null;
        openedWindow?.SetActive(false);
    }

    public void CloseThisWindow()
    {
        OpenedWindow = null;
        gameObject?.SetActive(false);
    }
}
