using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager
{
    private Misc.Input _input;

    public Misc.Input.BuildActions Build => _input.Build;

    public InputManager(){
        Awake();

        GM.Ins.EFocus += OnFocus;
        GM.Ins.ELeave += OnLeave;
    }

    public void OnDestroy(){
        GM.Ins.EFocus -= OnFocus;
        GM.Ins.ELeave -= OnLeave;
    }

    void Awake(){
        _input = new Misc.Input();
    }

    void OnFocus(){
        _input.Enable();
    }

    void OnLeave(){
        _input.Disable();
    }

    public void Enable() {
        _input.Enable();
    }

    public void Disable() {
        _input.Disable();
    }
}