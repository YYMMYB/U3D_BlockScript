using UnityEngine;

public class InputManager
{

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
    }

    void OnFocus(){
    }

    void OnLeave(){
    }
}