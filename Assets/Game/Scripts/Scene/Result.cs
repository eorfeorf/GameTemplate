using GameFramework.Scene;
using UnityEngine;

namespace Game.Scripts.Scene
{
    public sealed class Result : SceneBase
    {
        private IScreenFader fader;
        private void Awake()
        {
            fader = FindObjectOfType<ScreenFaderBase>();
        }

        private async void OnEnable()
        {
            await fader.FadeIn();
        }

        private async void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                await fader.FadeOut();
                isEnd = true;
            }
        }
    }
}
