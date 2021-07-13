using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Manipulator : MonoBehaviour
{
    public int tier = 0;
    public float maxAvailableDistance = 8;
    public float properDistance = 4;
    private Misc.Input.BuildActions BuildInput => GM.Ins.InputManager.Build;
    private Frame CurFrame => GM.Ins.CurFrame;
    private Camera CurCam => GM.Ins.CurCam;

    private void Awake(){
        BuildInput.Act1.performed += OnAct1;
    }

    private void OnAct1(InputAction.CallbackContext context){
        var posSS = BuildInput.ActPos.ReadValue<Vector2>();
        var ray = CurCam.ScreenPointToRay(posSS);
        Coord coord;
        if (CurFrame.RayCast(ray, out var hit, maxAvailableDistance)){
            coord = CurFrame.COnTier(hit.pointCoord, tier) + hit.normal/2;
        }
        else{
            coord = CurFrame.Pos2C(ray.GetPoint(properDistance), tier);
        }

        CurFrame.AttachBlock(coord, new TestBlock());
    }

    private void OnDestroy(){
        GM.Ins.InputManager.Build.Act1.performed -= OnAct1;
    }
}

public class TestBlock : IBlock
{
    public Coord Coord { get; set; }
    public Frame Frame { get; set; }
    public bool isInFramework { get; set; }
}