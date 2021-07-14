using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulator : MonoBehaviour
{
    public int tier = 0;
    public float maxAvailableDistance = 8;
    public float properDistance = 4;
    private Frame CurFrame {get{return GM.Ins.CurFrame;}}
    private Camera CurCam { get { return GM.Ins.CurCam; } }

    private void Update(){
        if(Input.GetMouseButtonDown(0)){
            OnAct1();
        }
    }

    private void OnAct1(){
        var posSS = Input.mousePosition;
        var ray = CurCam.ScreenPointToRay(posSS);
        Coord coord;
        Frame.HitInfo hit;
        if (CurFrame.RayCast(ray, out hit, maxAvailableDistance)){
            coord = CurFrame.COnTier(hit.pointCoord, tier) + hit.normal/2;
        }
        else{
            coord = CurFrame.Pos2C(ray.GetPoint(properDistance), tier);
        }

        CurFrame.AttachBlock(coord, new TestBlock());
    }

    private void OnDestroy(){
    }
}

public class TestBlock : IBlock
{
    public Coord Coord { get; set; }
    public Frame Frame { get; set; }
    public bool isInFrame { get; set; }
    public int? BindId { get; set; }
}