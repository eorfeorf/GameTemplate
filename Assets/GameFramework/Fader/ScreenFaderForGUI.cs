using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameFramework.Fader;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFaderForGUI : ScreenFaderBase
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Material originalMaterial;
    [SerializeField] private RawImage rawImage;
    [SerializeField] private Color defaultColor = Color.black;
    [SerializeField] private float defaultTime = 0.5f;

    private float timer;
    private Material mat;
    private static readonly int Alpha = Shader.PropertyToID("_Alpha");
    private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");
    

    private void Awake()
    {
        canvas.worldCamera = Camera.current;
        mat = new Material(originalMaterial);
        rawImage.material = mat;
    }

    public override async UniTask FadeIn(float time, Color color, CancellationToken ct)
    {
        Debug.Log("[Fade] In Start");
        mat.SetColor(BaseColor, color);
        timer = 0;

        try
        {
            await FadeIn_Impl(time, mat, ct);
        }
        catch (Exception)
        {
            mat.SetFloat(Alpha, 0f);
        }
    }

    public override async UniTask FadeOut(float time, Color color, CancellationToken ct)
    {
        Debug.Log("[Fade] Out Start");
        mat.SetColor(BaseColor, color);
        timer = 0;

        try
        {
            await FadeOut_Impl(time, mat, ct);
        }
        catch (Exception)
        {
            mat.SetFloat(Alpha, 1f);
        }
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
            if (timer > time)
            {
                Debug.Log("[Fade] In End");
                onFadeEnd.Value = Unit.Default;
                return;
            }

            timer += Time.deltaTime;
            var alpha = Mathf.Max(0f,1f - (timer / time));
            material.SetFloat(Alpha, alpha);
            Debug.Log($"[Fade] {alpha}");

            await UniTask.Yield(PlayerLoopTiming.Update, ct);
        }
    }

    private async UniTask FadeOut_Impl(float time, Material material, CancellationToken ct)
    {
        for (;;)
        {
            if (timer > time)
            {
                Debug.Log("[Fade] Out End");
                onFadeEnd.Value = Unit.Default;
                return;
            }

            timer = timer + Time.deltaTime;
            var alpha = Mathf.Min(1f, timer / time);
            material.SetFloat(Alpha, alpha);
            Debug.Log($"[Fade] {alpha}");

            await UniTask.Yield(PlayerLoopTiming.PostLateUpdate, ct);
        }
    }

    #endregion
}