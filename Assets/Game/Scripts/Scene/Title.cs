using UniRx;
using UnityEngine;

public sealed class Title : SceneBase
{
    private TitleView view;

    protected override void Awake()
    {
        base.Awake();
        view = GetComponent<TitleView>();
    }

    private void Start()
    {
        view.OnClickStartButton.SkipLatestValueOnSubscribe().Subscribe(async _ =>
        {
            await fader.FadeOut(ct);
            isEnd = true;
        }).AddTo(this);

        view.OnClickSettingButton.SkipLatestValueOnSubscribe().Subscribe(_ =>
        {
            
        }).AddTo(this);

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isEnd = true;
        }
    }
}