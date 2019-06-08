using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFirstActiveWindow : MonoBehaviour
{
    private ToggleWindow WindowScript = null;

    void Awake()
    {
        WindowScript = transform.parent.GetComponent<ToggleWindow>();
        WindowScript.SetActiveWindow(gameObject);
    }
}
