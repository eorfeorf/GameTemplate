using UniRx;
using UnityEngine;

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
            IsEnd = true;
        }).AddTo(this);
        
        view.OnClickSettingButton.SkipLatestValueOnSubscribe().Subscribe( _ =>
        {
            
        }).AddTo(this);
        
        view.OnClickExitButton.SkipLatestValueOnSubscribe().Subscribe(async _ =>
        {
            await fader.FadeOut();
            IsEnd = true;
        }).AddTo(this);
    }

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