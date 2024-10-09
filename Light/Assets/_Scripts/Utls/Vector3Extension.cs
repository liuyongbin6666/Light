using UnityEngine;

public static class Vector3Extension
{
    public static Vector3 ChangeX(this Vector3 v, float x) => new(x, v.y, v.z);
    public static Vector3 ChangeY(this Vector3 v, float y) => new(v.x, y, v.z);
    public static Vector3 ChangeZ(this Vector3 v, float z) => new(v.x, v.y, z);
    public static Vector3 ChangeXY(this Vector3 v, float x, float y) => new(x, y, v.z);
    public static Vector3 ChangeXZ(this Vector3 v, float x, float z) => new(x, v.y, z);
    public static Vector3 ChangeYZ(this Vector3 v, float y, float z) => new(v.x, y, z);
    public static Vector2 ChangeX(this Vector2 v, float x) => new(x, v.y);
    public static Vector2 ChangeY(this Vector2 v, float y) => new(v.x, y);
    public static Vector2 ToVector2(this Vector3 v) => new(v.x, v.y);
    public static Vector3 ToVector3(this Vector2 v, float z = 0) => new(v.x, v.y, z);
}