using System;
using UnityEngine;

public class Graph : MonoBehaviour {
    [SerializeField, Range(10, 150)] private int iResolution = 10;
    [SerializeField] private Transform pointPrefab;
    [SerializeField] private FunctionLibrary.FunctionName functionName;
    [SerializeField] private Vector2 xLimit = new Vector2(-1f, 1f);

    private Transform[] points;
    void Awake() {
        points = new Transform[iResolution * iResolution];
        var position = Vector3.zero;
        for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++) {
            if (x == iResolution) {
                x = 0;
                z += 1;
            }
            var point = points[i] = Instantiate(pointPrefab);
            point.SetParent(transform, false);
            var progress = (float) x / (iResolution - 1);
            var progressZ = (float) z / (iResolution - 1);
            position.x = Mathf.Lerp(xLimit.x, xLimit.y, progress);
            position.z = Mathf.Lerp(xLimit.x, xLimit.y, progressZ);
            point.localPosition = position;
            point.localScale = Vector3.one * (Mathf.Abs(xLimit.y - xLimit.x) / iResolution);
        }
    }

    // Update is called once per frame
    void Update() {
        float time = Time.time;
        for (int i = 0; i < points.Length; i++) {
            var point = points[i];
            var position = point.localPosition;
            var func = FunctionLibrary.GetFunctoion(functionName);
            position.y = func(position.x, position.z, time);
            point.localPosition = position;
        }
    }
}
