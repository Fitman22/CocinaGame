using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    Controls inputMAP;
    Controls.ControlMapActions Playercontrols;
    public static InputController instance;
    void Awake()
    {
        inputMAP = new Controls();
        Playercontrols = inputMAP.ControlMap;
        instance = this;
    }
    public Vector2 getMove()
    {
        return Playercontrols.Move.ReadValue<Vector2>();
    }
    public Controls.ControlMapActions getTouch()
    {
        return Playercontrols;
    }
    private void OnEnable() => inputMAP.Enable();
    private void OnDestroy() => inputMAP.Disable();
}
