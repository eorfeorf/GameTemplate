using System;
using UnityEngine;

public sealed class Title : SceneBase
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            IsEnd = true;
        }
    }
}