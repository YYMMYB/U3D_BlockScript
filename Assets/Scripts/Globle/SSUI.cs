using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class SSUI : MonoBehaviour {
    public Text Info;
    public InputField Input;
    private Manipulator Manipulator => GM.Ins.Manipulator;

    private bool active = false;
    private void Awake() {
        GM.Ins.EStart += OnStart;
    }

    private void OnDestroy() {
        GM.Ins.EStart -= OnStart;
    }

    void OnStart() {
        Input.text = Manipulator.tier.ToString();
        active = true;
    }

    void Update() {
        if (!active) return;

        int.TryParse(Input.text, out var curTier);
        if (curTier != Manipulator.tier) {
            Manipulator.tier = curTier;
        }

        var sb = new StringBuilder();
        sb.Append("操作说明: 目前没有时间, 按空格会执行命令");
        sb.Append("动作(1,2键修改): ");
        sb.AppendLine(Manipulator.actType.ToString());
        sb.Append("方块(滚轮修改): ");
        sb.AppendLine(Manipulator.blockType.ToString());
        sb.Append("层级(输入框 1): ");
        sb.AppendLine(Manipulator.tier.ToString());
        Info.text = sb.ToString();
    }
}