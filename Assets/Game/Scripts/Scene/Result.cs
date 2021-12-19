using GameFramework.Scene;
using UnityEngine;

namespace Game.Scripts.Scene
{
    public sealed class Result : SceneBase
    {
        protected override void Awake()
        {
            base.Awake();
        }

        private async void OnEnable()
        {
            await fader.FadeIn(ct);
        }

        private async void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                await fader.FadeOut(ct);
                isEnd = true;
            }
        }
    }
}
