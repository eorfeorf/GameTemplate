<<<<<<< HEAD
using System;
=======
using System.Threading;
using Cysharp.Threading.Tasks;
using GameFramework.Scene;
>>>>>>> 22ce05d... リファクタリング
using UnityEngine;

public sealed class InGame : SceneBase
{
<<<<<<< HEAD
    private IScreenFader fader;
    
    private void Awake()
    {
        fader = FindObjectOfType<ScreenFaderBase>();
    }

    private void OnEnable()
    {
        fader.FadeIn();
    }
=======
    public sealed class InGame : SceneBase
    {
        protected override void Awake()
        {
            base.Awake();
        }

        private async void OnEnable()
        {
            await fader.FadeIn(ct);
        }
>>>>>>> 22ce05d... リファクタリング

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
<<<<<<< HEAD
            IsEnd = true;
=======
            if (Input.GetKeyDown(KeyCode.X))
            {
                await fader.FadeOut(ct);
                isEnd = true;
            }
>>>>>>> 22ce05d... リファクタリング
        }
    }
}
