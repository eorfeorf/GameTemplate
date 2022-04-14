using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public abstract class ScreenFaderBase : MonoBehaviour, IScreenFader
{
    public abstract UniTask FadeIn(float time, Color color, CancellationToken ct);
    public abstract UniTask FadeOut(float time, Color color, CancellationToken ct);

    public abstract UniTask FadeIn(float time, CancellationToken ct);
    public abstract UniTask FadeOut(float time, CancellationToken ct);

    public abstract UniTask FadeIn(CancellationToken ct);
    public abstract UniTask FadeOut(CancellationToken ct);
    public IReactiveProperty<Unit> OnFadeEnd => onFadeEnd;
    protected IReactiveProperty<Unit> onFadeEnd = new ReactiveProperty<Unit>();
}
