using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Scene Script 简写为 SS
public class SSBuild : MonoBehaviour
{
    public Frame InitFrame;
    public Camera InitCamera;

    // TODO 加载时, 无法保证最先执行
    private void Awake(){
        GM.Ins.CurFrame = InitFrame;
        GM.Ins.CurCam = InitCamera;
    }

    // TODO 卸载场景的处理. OnDestroy 无法保证最后执行
}