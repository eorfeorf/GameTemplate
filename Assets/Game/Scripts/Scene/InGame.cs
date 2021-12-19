using UnityEngine;

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

    private async void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            await fader.FadeOut(ct);
            isEnd = true;
        }
    }
}