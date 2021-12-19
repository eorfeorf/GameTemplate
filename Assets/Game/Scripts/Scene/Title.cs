<<<<<<< HEAD
=======
using Cysharp.Threading.Tasks.Triggers;
using GameFramework.Scene;
>>>>>>> 22ce05d... リファクタリング
using UniRx;
using UnityEngine;

public sealed class Title : SceneBase
{
<<<<<<< HEAD
    private IScreenFader fader;
    private TitleView view;
    
    private void Awake()
    {
        fader = FindObjectOfType<ScreenFaderBase>();
        view = GetComponent<TitleView>();
    }
=======
    public sealed class Title : SceneBase
    {
        private TitleView view;

        protected override void Awake()
        {
            base.Awake();
            view = GetComponent<TitleView>();
        }
>>>>>>> 22ce05d... リファクタリング

    private void Start()
    {
        view.OnClickStartButton.SkipLatestValueOnSubscribe().Subscribe(async _ =>
        {
<<<<<<< HEAD
            await fader.FadeOut();
            IsEnd = true;
        }).AddTo(this);
=======
            view.OnClickStartButton.SkipLatestValueOnSubscribe().Subscribe(async _ =>
            {
                await fader.FadeOut(ct);
                isEnd = true;
            }).AddTo(this);
>>>>>>> 22ce05d... リファクタリング
        
        view.OnClickSettingButton.SkipLatestValueOnSubscribe().Subscribe( _ =>
        {
            
        }).AddTo(this);
        
<<<<<<< HEAD
        view.OnClickExitButton.SkipLatestValueOnSubscribe().Subscribe(async _ =>
        {
            await fader.FadeOut();
            IsEnd = true;
        }).AddTo(this);
    }
=======
            view.OnClickExitButton.SkipLatestValueOnSubscribe().Subscribe(async _ =>
            {
                await fader.FadeOut(ct);
                isEnd = true;
            }).AddTo(this);
        }

        private async void OnEnable()
        {
            await fader.FadeIn(10.0f, ct);
        }
>>>>>>> 22ce05d... リファクタリング

    private async void OnEnable()
    {
        await fader.FadeIn(1f);
        Debug.Log("[Scene] Title: OnEnable");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            IsEnd = true;
        }
    }
}