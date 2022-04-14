using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public interface IScreenFader
{
    public UniTask FadeIn(float time, Color color, CancellationToken ct);
    public UniTask FadeOut(float time, Color color, CancellationToken ct);
    
    public UniTask FadeIn(float time, CancellationToken ct);
    public UniTask FadeOut(float time, CancellationToken ct);

    public UniTask FadeIn(CancellationToken ct);
    public UniTask FadeOut(CancellationToken ct);

    public IReactiveProperty<Unit> OnFadeEnd { get; }
}
