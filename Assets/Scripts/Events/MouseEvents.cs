using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvents : MonoBehaviour
{
    public delegate void MouseClickDelegate();

    public MouseClickDelegate MouseClick;
    public MouseClickDelegate MouseRightClick;
    public MouseClickDelegate MouseLeftClick;
    public MouseClickDelegate MouseMiddleClick;

    //Update ou Mudar para OnMouseClick e colocar em um objeto com collider
    private void Update()
    {
        if(Input.GetMouseButton(0)) MouseLeftClick?.Invoke();
        if(Input.GetMouseButton(1)) MouseRightClick?.Invoke();
        if(Input.GetMouseButton(2)) MouseMiddleClick?.Invoke();
        MouseClick?.Invoke();
    }

}
