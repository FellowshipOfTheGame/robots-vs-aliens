using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveButtonBehavior : MonoBehaviour
{
    private RemoveSelector RemoveScript;

    Image ImageComponent = null;
    [SerializeField] private MouseEvents MouseScript = null;
    [SerializeField] private Sprite ActiveImage = null;
    [SerializeField] private Sprite DeactiveImage = null;

    // Start is called before the first frame update
    private void Awake()
    {
        ImageComponent = GetComponent<Image>();

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
