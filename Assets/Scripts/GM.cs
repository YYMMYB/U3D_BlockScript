using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public static GM Ins;

    public SaveManager SaveManager;
    public InputManager InputManager;
    public Frame CurFrame;
    public Camera CurCam;

    public event Action EStart;
    public event Action EPause;
    public event Action EResume;
    public event Action EFocus;
    public event Action ELeave;


    private void Awake(){
        Ins = this;

        SaveManager = new SaveManager();
        InputManager = new InputManager();
    }

    IEnumerator Start(){
        yield return LoadScenesAsync();
        EStart?.Invoke();
    }

    private void OnApplicationPause(bool pauseStatus){
        if (pauseStatus){
            EPause?.Invoke();
        }
        else{
            EResume?.Invoke();
        }
    }

    private void OnApplicationFocus(bool hasFocus){
        if (hasFocus){
            EFocus?.Invoke();
        }
        else{
            ELeave?.Invoke();
        }
    }

    private IEnumerator LoadScenesAsync(){
        var asyncList = new List<AsyncOperation>();
        asyncList.Add(SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive));
        asyncList.Add(SceneManager.LoadSceneAsync("Build", LoadSceneMode.Additive));

        while (true){
            var b = true;
            foreach (var asyncOperation in asyncList){
                if (!asyncOperation.isDone){
                    b = false;
                    break;
                }
            }
            if (b) break;

            yield return null;
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Build"));
    }
}