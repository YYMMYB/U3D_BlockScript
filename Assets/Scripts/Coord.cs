using UnityEngine;
using UnityEngine.Assertions;

public struct CoordInt
{
    public Vector3Int pos { get; set; }
    public int level { get; set; }

    public static implicit operator CoordInt(Coord coord)
    {
        return new CoordInt(coord);
    }

    public CoordInt(Coord coord)
    {
        pos = Vector3Int.FloorToInt(coord.pos);
        level = coord.level;
    }

    public override string ToString()
    {
        return $"{nameof(pos)}: {pos}, {nameof(level)}: {level}";
    }
}

public struct Coord
{
    public Vector3 pos { get; set; }
    public int level { get; set; }

    public Coord(Vector3 pos, int level)
    {
        this.pos = pos;
        this.level = level;
    }

    public Coord(float x, float y, float z, int level) : this(new Vector3(x, y, z), level)
    {
    }

    public Coord(CoordInt coordInt)
    {
        pos = coordInt.pos;
        level = coordInt.level;
    }

    public static implicit operator Coord(CoordInt coord)
    {
        return new Coord(coord);
    }

    public static Coord operator +(Coord a, Coord b)
    {
        Assert.AreEqual(a.level, b.level, $"目前两个L不同的Coord 无法相加. {a}, {b}");
        return a + b.pos;
    }

    public static Coord operator +(Coord a, Vector3 b){
        return new Coord(a.pos + b, a.level);
    }

    public static Coord operator -(Coord a) => new Coord(-a.pos, a.level);
    public static Coord operator -(Coord a, Coord b) => a + -b;
    public static Coord operator -(Coord a, Vector3 b) => a + -b;

    public override string ToString()
    {
        return $"{nameof(pos)}: {pos}, {nameof(level)}: {level}";
    }
}