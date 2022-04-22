using System.Collections;
using System.Collections.Generic;
using GameFramework.Tween;
using UnityEditor;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float t = 0f;
    
    void Update()   
    {
        float sec = 10;
        t += Time.deltaTime;

        var tt = t / sec;

        transform
            .Translate(new Vector3(0f, 0f, 0f), new Vector3(5f, 0f, 0f), tt)
            .Rotate(new Vector3(0f, 0f, 0f), new Vector3(360f, 0f, 0f), tt)
            .Scale(new Vector3(1f, 3f, 1f), new Vector3(1f, 1f, 1f), tt);
    }
}
