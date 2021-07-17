using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameCmdMng {
    private struct RemoveInfo {
        public IFrameCmdSender sender;
        public CoordInt target;
    }

    private struct BindInfo {
        public IFrameCmdSender sender;
        public ICollection<CoordInt> target;
    }

    private struct UnbindInfo {
        public IFrameCmdSender sender;
        public ICollection<CoordInt> target;
    }

    private struct SpawnInfo {
        public IFrameCmdSender sender;
        public CoordInt target;
        public IBlockForm blockForm;
    }

    public Frame Frame;

    private HashSet<BindInfo> bindCmds = new HashSet<BindInfo>();
    private HashSet<UnbindInfo> unbindCmds = new HashSet<UnbindInfo>();
    private Dictionary<CoordInt, HashSet<SpawnInfo>> spawnCmds = new Dictionary<CoordInt, HashSet<SpawnInfo>>();
    private Dictionary<CoordInt, HashSet<RemoveInfo>> removeCmds = new Dictionary<CoordInt, HashSet<RemoveInfo>>();

    private Dictionary<int, HashSet<CoordInt>> binds = new Dictionary<int, HashSet<CoordInt>>();

    public FrameCmdMng(Frame frame) {
        Frame = frame;
    }


    private int _lastBindId = 1;

    int GetNewBindId() {
        return _lastBindId++;
    }

    protected void GetBindBlocks(ICollection<CoordInt> coords, out HashSet<int> bindIds, out HashSet<CoordInt> unBindBlocks) {
        bindIds = new HashSet<int>();
        unBindBlocks = new HashSet<CoordInt>();
        foreach (var coord in coords) {
            if (!Frame.Blocks.ContainsKey(coord)) {
                continue;
            }

            var id = Frame.Blocks[coord].block.BindId;
            if (id.HasValue) {
                if (!binds.ContainsKey(id.Value)) {
                    bindIds.Add(id.Value);
                }
            }
            else {
                unBindBlocks.Add(coord);
            }
        }
    }

    public void XctBindBlocks() {
        foreach (var bindCmd in bindCmds) {
            var coords = bindCmd.target;

            HashSet<int> bindIds;
            HashSet<CoordInt> unBindBlocks;
            GetBindBlocks(coords, out bindIds, out unBindBlocks);

            int targetId = 0;
            if (bindIds.Count > 0) {
                bool first = true;
                foreach (var curId in bindIds) {
                    if (first) {
                        targetId = curId;
                        first = false;
                        continue;
                    }

                    var targetSet = binds[targetId];
                    var curSet = binds[curId];
                    targetSet.UnionWith(curSet);
                    foreach (var coord in curSet) {
                        Frame.Blocks[coord].block.BindId = targetId;
                    }

                    binds.Remove(curId);
                }

                foreach (var coordInt in unBindBlocks) {
                    var targetSet = binds[targetId];
                    targetSet.Add(coordInt);
                    Frame.Blocks[coordInt].block.BindId = targetId;
                }
            }
            else {
                targetId = GetNewBindId();
                binds.Add(targetId, unBindBlocks);
            }
        }
    }

    public void XctRemoveBlocks() {
        var coords = removeCmds.Keys;
        HashSet<int> bindIds;
        HashSet<CoordInt> unBindBlocks;
        GetBindBlocks(coords, out bindIds, out unBindBlocks);

        foreach (var bindId in bindIds) {
            foreach (var coordInt in binds[bindId]) {
                Frame.DetachBlock(coordInt);
            }
        }

        foreach (var coordInt in unBindBlocks) {
            Frame.DetachBlock(coordInt);
        }
    }

    public void XctSpawnBlocks() {
        foreach (var kv in spawnCmds) {
            var coord = kv.Key;
            var cmds = kv.Value;
            if (cmds.Count == 1) {
                if (Frame.CanAttach(coord)) {
                    var block = new TestBlock();
                    Frame.AttachBlock(coord, block);
                }
            }
            else {
                if (cmds.Count > 1)
                    Debug.Log("在 " + coord + " 无法 Spawn 多个方块");
            }
        }
    }

    public void BindBlocksCmd(IFrameCmdSender sender, ICollection<CoordInt> target) {
        var info = new BindInfo() {
            sender = sender,
            target = target,
        };
        bindCmds.Add(info);
    }

    public void SpawnBlockCmd(IFrameCmdSender sender, Coord target, IBlockForm blockForm) {
        var info = new SpawnInfo() {
            sender = sender,
            target = target,
            blockForm = blockForm,
        };
        HashSet<SpawnInfo> infos;
        if (!spawnCmds.TryGetValue(target, out infos)) {
            infos = new HashSet<SpawnInfo>();
            spawnCmds.Add(target, infos);
        }

        infos.Add(info);
    }

    public void RemoveBlockCmd(IFrameCmdSender sender, Coord target) {
        var info = new RemoveInfo() {
            sender = sender,
            target = target,
        };
        HashSet<RemoveInfo> infos;
        if (!removeCmds.TryGetValue(target, out infos)) {
            infos = new HashSet<RemoveInfo>();
            removeCmds.Add(target, infos);
        }

        infos.Add(info);
    }

    // 这个地方还是换成 Playable 做吧
    IEnumerator XctImmediatelyInstantStage() {
        // 处理数据
        yield return null;
        // 删除
        yield return null;
        // 增加, 复制
        yield return null;
        // 解绑, 绑定 [可抵消]
        yield return null;
        // 合并
        yield return null;
        // 细分
        yield return null;
    }

    IEnumerator XctSustainedStage() {
        // 移动, 旋转, 缩放
        yield return null;
    }

    IEnumerator XctDelayedInstantStage() {
        yield return null;
    }

    public void ExecuteAllCmd() {
        XctBindBlocks();
        XctRemoveBlocks();
        XctSpawnBlocks();
        ClearAllCmds();
    }

    void ClearAllCmds() {
        bindCmds.Clear();
        spawnCmds.Clear();
        removeCmds.Clear();
    }
}