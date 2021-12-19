using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ScreenFader : ScreenFaderBase
{
    [SerializeField] private ForwardRendererData rendererData;
    [SerializeField] private Color defaultColor = Color.black;
    [SerializeField] private float defaultTime = 0.5f;

    private Material mat;
    private float timer;
    private static readonly int Alpha = Shader.PropertyToID("_Alpha");
    private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");

    private void Awake()
    {
        DontDestroyOnLoad(this);

        var feature = rendererData.rendererFeatures.Find(item => item is ScreenFadeFeature);
        if (feature is ScreenFadeFeature screenFade)
        {
            mat = Instantiate(screenFade.settings.material);
            screenFade.settings.runTimeMaterial = mat;
        }
    }

    public override async UniTask FadeIn(float time, Color color, CancellationToken ct)
    {
        Debug.Log("[Fade] In Start");
        mat.SetColor(BaseColor, color);
        timer = 0;

        await FadeIn_Impl(time, mat, ct);
    }

    public override async UniTask FadeOut(float time, Color color, CancellationToken ct)
    {
        Debug.Log("[Fade] Out Start");
        mat.SetColor(BaseColor, color);
        timer = 0;

        await FadeOut_Impl(time, mat, ct);
    }

    public override async UniTask FadeIn(float time, CancellationToken ct)
    {
        await FadeIn(time, defaultColor, ct);
    }

    public override async UniTask FadeOut(float time, CancellationToken ct)
    {
        await FadeOut(time, defaultColor, ct);
    }

    public override async UniTask FadeIn(CancellationToken ct)
    {
        await FadeIn(defaultTime, defaultColor, ct);
    }

    public override async UniTask FadeOut(CancellationToken ct)
    {
        await FadeOut(defaultTime, defaultColor, ct);
    }

    #region Implement

    private async UniTask FadeIn_Impl(float time, Material material, CancellationToken ct)
    {
        for (;;)
        {
            if (timer >= time)
            {
                Debug.Log("[Fade] In End");
                return;
            }

            timer = Mathf.Clamp(timer + Time.deltaTime, 0f, 1f);
            var alpha = 1f - (timer / time);
            material.SetFloat(Alpha, alpha);

            await UniTask.Yield(PlayerLoopTiming.Update, ct);
        }
    }

    private async UniTask FadeOut_Impl(float time, Material material, CancellationToken ct)
    {
        for (;;)
        {
            if (timer >= time)
            {
                Debug.Log("[Fade] Out End");
                return;
            }

            timer = Mathf.Clamp(timer + Time.deltaTime, 0f, 1f);
            var alpha = timer / time;
            material.SetFloat(Alpha, alpha);

            await UniTask.Yield(PlayerLoopTiming.PostLateUpdate, ct);
        }
    }

    #endregion
}