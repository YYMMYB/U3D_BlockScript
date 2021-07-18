using System;
using System.Collections.Generic;
using System.Linq;
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
        if (Physics.Raycast(ray, out var hit, maxDistance)) {
            for (int i = MinTier; i <= MaxTier; i++) {
                var coordF = Pos2C(hit.point, i);
                var normal = Dir2C(hit.normal).normalized;
                if (Blocks.TryGetValue(coordF - normal / 2, out var block)) {
                    hitInfo = new HitInfo() {
                        pointCoord = coordF,
                        normal = normal,
                    };
                    return true;
                }
            }
        }

        hitInfo = default;
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

    // 局部坐标系
    public float SizeOnLevel(int tier) {
        return Mathf.Pow(D, tier);
    }

    // 局部坐标系
    public Coord COnTier(Coord coord, int tier) {
        return new Coord(coord.pos / SizeOnLevel(tier - coord.level), tier);
    }

    public void AttachBlock(Coord coordF, IBlock block) {
        var coord = (CoordInt) coordF;
#if UNITY_EDITOR || DEVELOPMENT_BUILD
        if (!CanAttach(coordF)) {
            Debug.LogWarning($"在: {this} 的 {coord} 位置, 无法增加方块: {block}");
        }
        else {
            Debug.Log($"在: {this} 的 {coord} 位置, 可以增加方块: {block}");
        }
#endif
        coordF = (Coord) coord + Vector3.one * 0.5f;
        var coordScale = SizeOnLevel(coordF.level);
        var posWS = C2Pos(coordF);
        var pos = transform.InverseTransformPoint(posWS);

        // Render
        var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.transform.SetParent(transform);
        go.transform.localPosition = pos;
        go.transform.localRotation = Quaternion.identity;
        go.transform.localScale = Vector3.one * coordScale;

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

    public bool CanAttach(Coord coordF) {
        var coord = (CoordInt) coordF;
        coordF = (Coord) coord + Vector3.one * 0.5f;
        var coordScale = SizeOnLevel(coordF.level);
        var posWS = C2Pos(coordF);
        var scale = coordScale * transform.lossyScale;
        var isCls = Physics.CheckBox(posWS, scale / 2 * (1 - epsilon), transform.rotation);
        return !isCls;
    }

    public IBlock DetachBlock(Coord coord) {
#if DEVELOPMENT_BUILD || UNITY_EDITOR
        if (!Blocks.ContainsKey(coord)) {
            Debug.Log("Frame 中没有方块");
        }
#endif
        var data = Blocks[coord];
        Destroy(data.go);
        DestroyImmediate(data.collider);
        Blocks.Remove(coord);
        data.block.isInFrame = false;
        data.block.Frame = null;
        return data.block;
    }

    public void MoveBlock(CoordInt coordI, Vector3 displacement) {
    }
}