using UnityEngine;

public sealed class Result : SceneBase
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void Initialize()
    {
        
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