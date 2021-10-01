using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFaderForGUI : ScreenFaderBase
{
    [SerializeField] private RawImage rawImage;
    [SerializeField] private Color defaultColor = Color.black;
    [SerializeField] private float defaultTime = 0.5f;

    private float timer;
    private Material mat;

    private CancellationToken cancellationToken;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        cancellationToken = this.GetCancellationTokenOnDestroy();
        mat = rawImage.material;
    }

    public override async UniTask FadeIn(float time, Color color)
    {
        Debug.Log("[Fade] In Start");
        mat.SetColor("_BaseColor", color);
        timer = 0;

        await FadeIn_Impl(cancellationToken, time, mat);
    }

    public override async UniTask FadeOut(float time, Color color)
    {
        Debug.Log("[Fade] Out Start");
        mat.SetColor("_BaseColor", color);
        timer = 0;

        await FadeOut_Impl(cancellationToken, time, mat);
    }

    public override async UniTask FadeIn(float time)
    {
        await FadeIn(time, defaultColor);
    }

    public override async UniTask FadeOut(float time)
    {
        await FadeOut(time, defaultColor);
    }

    public override async UniTask FadeIn()
    {
        await FadeIn(defaultTime, defaultColor);
    }

    public override async UniTask FadeOut()
    {
        await FadeOut(defaultTime, defaultColor);
    }

    #region Implement
    private async UniTask FadeIn_Impl(CancellationToken ct, float time, Material mat)
    {
        for (;;)
        {
            if (timer >= time)
            {
                Debug.Log("[Fade] In End");
                return;
            }

            timer = Mathf.Clamp(timer + Time.deltaTime, 0f, time);
            var alpha = 1f - (timer / time);
            mat.SetFloat("_Alpha", alpha);
            Debug.Log(alpha);

            await UniTask.Yield(PlayerLoopTiming.Update, ct);
        }
    }

    private async UniTask FadeOut_Impl(CancellationToken ct, float time, Material mat)
    {
        for (;;)
        {
            if (timer >= time)
            {
                Debug.Log("[Fade] Out End");
                return;
            }

            timer = Mathf.Clamp(timer + Time.deltaTime, 0f, time);
            var alpha = timer / time;
            mat.SetFloat("_Alpha", alpha);

            await UniTask.Yield(PlayerLoopTiming.PostLateUpdate, ct);
        }
    }

    #endregion
}