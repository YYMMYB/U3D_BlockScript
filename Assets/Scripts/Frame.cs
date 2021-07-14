using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour {
    public struct BlockInfo {
        public IBlock block;
        public Collider collider;
        public GameObject go;
    }

    public struct HitInfo {
        public Coord pointCoord;
        public Vector3 normal;
    }

    public int MaxTier = 4;
    public int MinTier = -2;
    public int D = 3;
    [Tooltip("物理射线检测允许的偏差")] public float epsilon = 0.005f;

    public Dictionary<CoordInt, BlockInfo> Blocks = new Dictionary<CoordInt, BlockInfo>();
    public FrameCmdMng CmdMng;

    private void Awake() {
        CmdMng = new FrameCmdMng(this);
    }

    public bool RayCast(Ray ray, out HitInfo hitInfo, float maxDistance) {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance)) {
            for (int i = MinTier; i <= MaxTier; i++) {
                var coordF = Pos2C(hit.point, i);
                var normal = Dir2C(hit.normal).normalized;
                BlockInfo block;
                if (Blocks.TryGetValue(coordF - normal / 2, out block)) {
                    hitInfo = new HitInfo() {
                        pointCoord = coordF,
                        normal = normal,
                    };
                    return true;
                }
            }
        }

        hitInfo = default(HitInfo);
        return false;
    }

    public Vector3 Dir2C(Vector3 dirWS) {
        return transform.InverseTransformDirection(dirWS);
    }

    public Coord Pos2C(Vector3 posWS, int tier) {
        var size = SizeOnLevel(tier);
        var pos = transform.InverseTransformPoint(posWS);
        var coordPos = pos / size;
        var coordInt = new Coord(coordPos, tier);
        return coordInt;
    }

    public Vector3 C2Pos(Coord coord) {
        var size = SizeOnLevel(coord.level);
        var posOS = coord.pos * size;
        var pos = transform.TransformPoint(posOS);
        return pos;
    }

    public float SizeOnLevel(int tier) {
        return Mathf.Pow(D, tier);
    }

    public Coord COnTier(Coord coord, int tier) {
        return new Coord(coord.pos / SizeOnLevel(tier - coord.level), tier);
    }

    public void AttachBlock(Coord coordF, IBlock block) {
        var coord = (CoordInt) coordF;
        coordF = (Coord) coord + Vector3.one * 0.5f;
        var coordScale = SizeOnLevel(coordF.level);
        var posWS = C2Pos(coordF);
        var pos = transform.InverseTransformPoint(posWS);
        var scale = coordScale * transform.localScale;
        var isCls = Physics.CheckBox(posWS, scale / 2 * (1 - epsilon), transform.rotation);
        if (!isCls) {
            // Render
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // DestroyImmediate(go.GetComponent<Collider>());
            go.transform.SetParent(transform);
            go.transform.localPosition = pos;
            go.transform.localRotation = Quaternion.identity;
            go.transform.localScale = Vector3.one * coordScale;

            // Physics
            // var cld = gameObject.AddComponent<BoxCollider>();
            // cld.center = pos;
            // cld.size = Vector3.one * coordScale;
            var cld = go.GetComponent<Collider>();

            // Data
            block.isInFrame = true;
            block.Frame = this;
            block.Coord = coord;
            Blocks.Add(coord, new BlockInfo {
                block = block,
                collider = cld,
                go = go,
            });
        }
        else {
            Debug.Log($"在: {this} 的 {coord} 位置, 无法增加方块: {block}");
        }
    }

    public IBlock DetachBlock(Coord coord) {
        var data = Blocks[coord];
        Destroy(data.go);
        DestroyImmediate(data.collider);
        Blocks.Remove(coord);
        data.block.isInFrame = false;
        return data.block;
    }

    public void MoveBlock(CoordInt coordI, Vector3 displacement) {
    }
}

public class FrameCmdMng {
    public Frame Frame;

    private Dictionary<int, HashSet<CoordInt>> binds = new Dictionary<int, HashSet<CoordInt>>();
    

    public FrameCmdMng(Frame frame) {
        Frame = frame;
    }


    private int _lastBindId = 1;

    int GetNewBindId() {
        return _lastBindId++;
    }

    public void BindBlocksCmd(ICollection<Coord> coords) {
        var bindIds = new HashSet<int>();
        var unBindBlocks = new HashSet<CoordInt>();
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

    public void SpawnBlockCmd(IFrameCmdSender sender, Coord target, IBlockForm blockForm) {
    }
    public void RemoveBlockCmd(IFrameCmdSender sender, Coord target) {
    }
    public void MoveBlockCmd(IFrameCmdSender sender, Coord from, Vector3 displacement) {
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
    }
}

public interface IBlockForm {
    
}
public interface IBlock {
    Coord Coord { get; set; }
    Frame Frame { get; set; }
    bool isInFrame { get; set; }
    int? BindId { get; set; }
}

public interface IFrameCmdSender {
}