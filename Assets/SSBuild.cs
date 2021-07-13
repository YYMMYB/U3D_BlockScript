using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scene Script 简写为 SS
public class SSBuild : MonoBehaviour
{
    public Frame InitFrame;
    public Camera InitCamera;

    private void Awake(){
        GM.Ins.CurFrame = InitFrame;
        GM.Ins.CurCam = InitCamera;
    }
}