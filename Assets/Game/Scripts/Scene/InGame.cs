using Game.Scripts.Stage;
using UnityEngine;

public sealed class InGame : SceneBase
{
    private Stage stage;
    
    protected override void Awake()
    {
        base.Awake();

        stage = new Stage();
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