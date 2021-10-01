using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public sealed class Title : SceneBase
{
    private IScreenFader fader;
    
    private void Awake()
    {
        fader = FindObjectOfType<ScreenFaderBase>();
    }

    private async void OnEnable()
    {
        await fader.FadeIn(1f);
        Debug.Log("Title: OnEnable");
    }

    private async void OnDisable()
    {
        await fader.FadeOut(3f);
        Debug.Log("Title: OnDisable");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            IsEnd = true;
        }
    }
}