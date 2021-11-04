using UniRx;
using UnityEngine;

public sealed class PlayerInputEventProvider : MonoBehaviour, IInputEventProvider
{
    public IReadOnlyReactiveProperty<bool> OnPushedMainButton { get; } = new ReactiveProperty<bool>();
    public IReadOnlyReactiveProperty<bool> OnPushedSubButton { get; } = new ReactiveProperty<bool>();
    public IReadOnlyReactiveProperty<float> OnVertical { get; } = new ReactiveProperty<float>();
    public IReadOnlyReactiveProperty<float> OnHorizontal { get; } = new ReactiveProperty<float>();

    private void Update()
    {
    }
}