using UniRx;
using UnityEngine;

public class TouchInfo
{
    public bool Active;
    public Touch Touch;

    public TouchInfo(bool active, Touch touch)
    {
        Active = active;
        Touch = touch;
    }
}

public interface IInputEventProvider
{
    public IReadOnlyReactiveProperty<float> OnVertical { get; }
    public IReadOnlyReactiveProperty<float> OnHorizontal { get; }
    public IReadOnlyReactiveProperty<Unit> OnPushedLeft { get; }
    public IReadOnlyReactiveProperty<Unit> OnPushedRight { get; }
    public IReadOnlyReactiveProperty<Unit> OnPushedUp { get; }
    public IReadOnlyReactiveProperty<Unit> OnPushedDown { get; }
    public IReadOnlyReactiveProperty<Unit> OnPushedDecide { get; }
    
    public IReadOnlyReactiveProperty<TouchInfo> OnTouched0 { get; }
    public IReadOnlyReactiveProperty<TouchInfo> OnTouched1 { get; }
    public IReadOnlyReactiveProperty<TouchInfo> OnTouched2 { get; }
    public IReadOnlyReactiveProperty<TouchInfo> OnTouched3 { get; }
    public IReadOnlyReactiveProperty<TouchInfo> OnTouched4 { get; }
    public IReadOnlyReactiveProperty<TouchInfo> OnTouched5 { get; }
    public IReadOnlyReactiveProperty<TouchInfo> OnTouched6 { get; }
    public IReadOnlyReactiveProperty<TouchInfo> OnTouched7 { get; }
    public IReadOnlyReactiveProperty<TouchInfo> OnTouched8 { get; }
    public IReadOnlyReactiveProperty<TouchInfo> OnTouched9 { get; }
}