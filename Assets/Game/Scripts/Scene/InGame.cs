using System;
using UnityEngine;

public sealed class InGame : SceneBase
{
    private IScreenFader fader;
    
    private void Awake()
    {
        fader = FindObjectOfType<ScreenFaderBase>();
    }

    private void OnEnable()
    {
        fader.FadeIn();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            IsEnd = true;
        }
    }
}
