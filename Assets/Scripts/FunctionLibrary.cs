using UnityEditor.IMGUI.Controls;
using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibrary
{
    public delegate float GraphFunction(float x, float z, float t);
    public enum FunctionName {
        Wave,
        MultiWave,
        Ripple
    }

    static GraphFunction[] functions = { Wave, MultiWave, Ripple };

    public static GraphFunction GetFunctoion(FunctionName func) {
        return functions[(int) func];
    }
    public static float Wave(float x, float z, float t) {
        var y = Sin(PI * (x + z + t));
        return y;
    }

    public static float MultiWave(float x, float z, float t) {
        var y = Sin(PI * (x + 0.5f * t)) + 0.5f * Sin(2f * PI * (z + t)) + Sin(PI * (x + z + 0.25f * t));
        return y * (1 / 2.5f);
    }

    public static float Ripple(float x, float z, float t) {
        var d = Sqrt(x * x + z * z);
        var y = Sin(PI * (4f * d - t));
        return y / (1f + 10f * d);
    }

}