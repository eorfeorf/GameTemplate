using UniRx;

public interface IInputEventProvider
{
    IReadOnlyReactiveProperty<float> OnVertical { get; }
    IReadOnlyReactiveProperty<float> OnHorizontal { get; }
    public IReadOnlyReactiveProperty<Unit> OnPushedLeft { get; }
    public IReadOnlyReactiveProperty<Unit> OnPushedRight { get; }
    public IReadOnlyReactiveProperty<Unit> OnPushedUp { get; }
    public IReadOnlyReactiveProperty<Unit> OnPushedDown { get; }
    public IReadOnlyReactiveProperty<Unit> OnPushedDecide { get; }
    public IReadOnlyReactiveProperty<Unit> OnPushedCancel { get; }
}