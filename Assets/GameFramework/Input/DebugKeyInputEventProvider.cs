using UniRx;
using UnityEngine;

public sealed class DebugKeyInputEventProvider : MonoBehaviour, IInputEventProvider
{
    public IReadOnlyReactiveProperty<float> OnVertical { get; } = new ReactiveProperty<float>();
    private readonly ReactiveProperty<float> onVertical = new ReactiveProperty<float>();
    public IReadOnlyReactiveProperty<float> OnHorizontal { get; } = new ReactiveProperty<float>();
    private readonly ReactiveProperty<float> onHorizontal = new ReactiveProperty<float>();
    public IReadOnlyReactiveProperty<Unit> OnPushedLeft { get; } = new ReactiveProperty<Unit>();
    private readonly ReactiveProperty<Unit> onPushedLeft = new ReactiveProperty<Unit>();
    public IReadOnlyReactiveProperty<Unit> OnPushedRight { get; } = new ReactiveProperty<Unit>();
    private readonly ReactiveProperty<Unit> onPushedRight = new ReactiveProperty<Unit>();
    public IReadOnlyReactiveProperty<Unit> OnPushedUp { get; } = new ReactiveProperty<Unit>();
    private readonly ReactiveProperty<Unit> onPushedUp = new ReactiveProperty<Unit>();
    public IReadOnlyReactiveProperty<Unit> OnPushedDown { get; } = new ReactiveProperty<Unit>();
    private readonly ReactiveProperty<Unit> onPushedDown = new ReactiveProperty<Unit>();
    public IReadOnlyReactiveProperty<Unit> OnPushedDecide { get; } = new ReactiveProperty<Unit>();
    private readonly ReactiveProperty<Unit> onPushedDecide = new ReactiveProperty<Unit>();
    public IReadOnlyReactiveProperty<Unit> OnPushedCancel { get; } = new ReactiveProperty<Unit>();
    private readonly ReactiveProperty<Unit> onPushedCancel = new ReactiveProperty<Unit>();

    private void Update()
    {
        onVertical.Value = Input.GetAxis("Vertical");
        onHorizontal.Value = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            onPushedLeft.Value = Unit.Default;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            onPushedRight.Value = Unit.Default;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            onPushedUp.Value = Unit.Default;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            onPushedDown.Value = Unit.Default;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            onPushedDecide.Value = Unit.Default;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            onPushedCancel.Value = Unit.Default;
        }
    }
}