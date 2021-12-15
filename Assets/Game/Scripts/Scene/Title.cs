using GameFramework.Scene;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Scene
{
    public sealed class Title : SceneBase
    {
        private IScreenFader fader;
        private TitleView view;
    
        private void Awake()
        {
            fader = FindObjectOfType<ScreenFaderBase>();
            view = GetComponent<TitleView>();
        }

        private void Start()
        {
            view.OnClickStartButton.SkipLatestValueOnSubscribe().Subscribe(async _ =>
            {
                await fader.FadeOut();
                isEnd = true;
            }).AddTo(this);
        
            view.OnClickSettingButton.SkipLatestValueOnSubscribe().Subscribe( _ =>
            {
            
            }).AddTo(this);
        
            view.OnClickExitButton.SkipLatestValueOnSubscribe().Subscribe(async _ =>
            {
                await fader.FadeOut();
                isEnd = true;
            }).AddTo(this);
        }

        private async void OnEnable()
        {
            await fader.FadeIn();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                isEnd = true;
            }
        }
    }
}