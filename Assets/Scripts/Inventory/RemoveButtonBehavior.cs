using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveButtonBehavior : MonoBehaviour
{
    private RemoveSelector RemoveScript;

    [SerializeField] Image ImageComponent;
    [SerializeField] private MouseEvents MouseScript;
    [SerializeField] private Sprite ActiveImage;
    [SerializeField] private Sprite DeactiveImage;

    // Start is called before the first frame update
    private void Awake()
    {
        if (MouseScript == null) MouseScript = FindObjectOfType<MouseEvents>();
        RemoveScript = GetComponent<RemoveSelector>();
        MouseScript.MouseClick += ChangeImage;
    }

    public void ChangeImage()
    {
        if (RemoveScript.isSelected())
        {
            ImageComponent.sprite = ActiveImage;
        }
        else
        {
            ImageComponent.sprite = DeactiveImage;
        }
    }
    
}
