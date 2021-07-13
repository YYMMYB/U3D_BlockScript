using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    public struct BlockInfo
    {
        public IBlock block;
        public Collider collider;
        public GameObject go;
    }

    public struct HitInfo
    {
        public Coord pointCoord;
        public Vector3 normal;
    }

    public int MaxTier = 4;
    public int MinTier = -2;
    public int D = 3;
    public Dictionary<CoordInt, BlockInfo> Blocks = new Dictionary<CoordInt, BlockInfo>();
    [Tooltip("物理射线检测允许的偏差")] public float epsilon = 0.005f;

    public bool RayCast(Ray ray, out HitInfo hitInfo, float maxDistance){
        if (Physics.Raycast(ray, out var hit, maxDistance)){
            for (int i = MinTier; i <= MaxTier; i++){
                var coordF = Pos2C(hit.point, i);
                var normal = Dir2C(hit.normal).normalized;
                if (Blocks.TryGetValue(coordF - normal / 2, out var block)){
                    hitInfo = new HitInfo()
                    {
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

    public Vector3 Dir2C(Vector3 dirWS){
        return transform.InverseTransformDirection(dirWS);
    }

    public Coord Pos2C(Vector3 posWS, int tier){
        var size = SizeOnLevel(tier);
        var pos = transform.InverseTransformPoint(posWS);
        var coordPos = pos / size;
        var coordInt = new Coord(coordPos, tier);
        return coordInt;
    }

    public Vector3 C2Pos(Coord coord){
        var size = SizeOnLevel(coord.level);
        var posOS = coord.pos * size;
        var pos = transform.TransformPoint(posOS);
        return pos;
    }

    public float SizeOnLevel(int tier){
        return Mathf.Pow(D, tier);
    }

    public Coord COnTier(Coord coord, int tier){
        return new Coord(coord.pos / SizeOnLevel(tier - coord.level), tier);
    }

    public void AttachBlock(Coord coordF, IBlock block){
        var coord = (CoordInt) coordF;
        coordF = (Coord) coord + Vector3.one * 0.5f;
        var coordScale = SizeOnLevel(coordF.level);
        var posWS = C2Pos(coordF);
        var pos = transform.InverseTransformPoint(posWS);
        var scale = coordScale * transform.localScale;
        var isCls = Physics.CheckBox(posWS, scale / 2 * (1 - epsilon), transform.rotation);
        if (!isCls){
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
            block.isInFramework = true;
            block.Frame = this;
            block.Coord = coord;
            Blocks.Add(coord, new BlockInfo
            {
                block = block,
                collider = cld,
                go = go,
            });
        }
        else{
            Debug.Log($"在: {this} 的 {coord} 位置, 无法增加方块: {block}");
        }
    }

    public IBlock DetachBlock(Coord coord){
        var data = Blocks[coord];
        Destroy(data.go);
        DestroyImmediate(data.collider);
        Blocks.Remove(coord);
        data.block.isInFramework = false;
        return data.block;
    }
}

public interface IBlock
{
    Coord Coord { get; set; }
    Frame Frame { get; set; }

    bool isInFramework { get; set; }
}