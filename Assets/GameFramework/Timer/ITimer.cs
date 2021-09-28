using UniRx;

public interface ITimer
{
    public IReactiveProperty<bool> IsEnd { get; }

    public void Reset();
}