using UniRx;
using UnityEngine;

public interface IInputEventProvider
{
    public IReadOnlyReactiveProperty<float> OnVertical { get; }
    public IReadOnlyReactiveProperty<float> OnHorizontal { get; }
    public IReadOnlyReactiveProperty<Unit> OnPushedLeft { get; }
    public IReadOnlyReactiveProperty<Unit> OnPushedRight { get; }
    public IReadOnlyReactiveProperty<Unit> OnPushedUp { get; }
    public IReadOnlyReactiveProperty<Unit> OnPushedDown { get; }
    public IReadOnlyReactiveProperty<Unit> OnPushedDecide { get; }

    public IReadOnlyReactiveProperty<Touch[]> OnTouches { get; }
}