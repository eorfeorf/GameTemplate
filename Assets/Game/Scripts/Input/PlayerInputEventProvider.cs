using UniRx;
using UnityEngine;

public sealed class PlayerInputEventProvider : MonoBehaviour, IInputEventProvider
{
    public IReadOnlyReactiveProperty<float> OnVertical => onVertical;
    private readonly ReactiveProperty<float> onVertical = new ReactiveProperty<float>();
    public IReadOnlyReactiveProperty<float> OnHorizontal => onHorizontal;
    private readonly ReactiveProperty<float> onHorizontal = new ReactiveProperty<float>();
    public IReadOnlyReactiveProperty<Unit> OnPushedLeft => onPushedLeft;
    private readonly ReactiveProperty<Unit> onPushedLeft = new ReactiveProperty<Unit>();
    public IReadOnlyReactiveProperty<Unit> OnPushedRight => onPushedRight;
    private readonly ReactiveProperty<Unit> onPushedRight = new ReactiveProperty<Unit>();
    public IReadOnlyReactiveProperty<Unit> OnPushedUp => onPushedUp;
    private readonly ReactiveProperty<Unit> onPushedUp = new ReactiveProperty<Unit>();
    public IReadOnlyReactiveProperty<Unit> OnPushedDown => onPushedDown;
    private readonly ReactiveProperty<Unit> onPushedDown = new ReactiveProperty<Unit>();
    public IReadOnlyReactiveProperty<Unit> OnPushedDecide => onPushedDecide;
    private readonly ReactiveProperty<Unit> onPushedDecide = new ReactiveProperty<Unit>();
    public IReadOnlyReactiveProperty<Unit> OnPushedCancel => onPushedCancel;
    private readonly ReactiveProperty<Unit> onPushedCancel = new ReactiveProperty<Unit>();

    public const int TouchNum = 10;
    public IReadOnlyReactiveProperty<TouchInfo> OnTouched0 => onTouched0;
    private ReactiveProperty<TouchInfo> onTouched0 = new ReactiveProperty<TouchInfo>();
    public IReadOnlyReactiveProperty<TouchInfo> OnTouched1 => onTouched1;
    private ReactiveProperty<TouchInfo> onTouched1 = new ReactiveProperty<TouchInfo>();
    public IReadOnlyReactiveProperty<TouchInfo> OnTouched2 => onTouched2;
    private ReactiveProperty<TouchInfo> onTouched2 = new ReactiveProperty<TouchInfo>();
    public IReadOnlyReactiveProperty<TouchInfo> OnTouched3 => onTouched3;
    private ReactiveProperty<TouchInfo> onTouched3 = new ReactiveProperty<TouchInfo>();
    public IReadOnlyReactiveProperty<TouchInfo> OnTouched4 => onTouched4;
    private ReactiveProperty<TouchInfo> onTouched4 = new ReactiveProperty<TouchInfo>();
    public IReadOnlyReactiveProperty<TouchInfo> OnTouched5 => onTouched5;
    private ReactiveProperty<TouchInfo> onTouched5 = new ReactiveProperty<TouchInfo>();
    public IReadOnlyReactiveProperty<TouchInfo> OnTouched6 => onTouched6;
    private ReactiveProperty<TouchInfo> onTouched6 = new ReactiveProperty<TouchInfo>();
    public IReadOnlyReactiveProperty<TouchInfo> OnTouched7 => onTouched7;
    private ReactiveProperty<TouchInfo> onTouched7 = new ReactiveProperty<TouchInfo>();
    public IReadOnlyReactiveProperty<TouchInfo> OnTouched8 => onTouched8;
    private ReactiveProperty<TouchInfo> onTouched8 = new ReactiveProperty<TouchInfo>();
    public IReadOnlyReactiveProperty<TouchInfo> OnTouched9 => onTouched9;
    private ReactiveProperty<TouchInfo> onTouched9 = new ReactiveProperty<TouchInfo>();

    private ReactiveProperty<TouchInfo>[] onTouches;


    private void Update()
    {
        onVertical.Value = Input.GetAxis("Vertical");
        onHorizontal.Value = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            onPushedLeft.SetValueAndForceNotify(Unit.Default);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            onPushedRight.SetValueAndForceNotify(Unit.Default);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            onPushedUp.SetValueAndForceNotify(Unit.Default);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            onPushedDown.SetValueAndForceNotify(Unit.Default);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            onPushedDecide.SetValueAndForceNotify(Unit.Default);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            onPushedCancel.SetValueAndForceNotify(Unit.Default);
        }

        var touches = UnityEngine.Input.touches;
        for (var i = 0; i < TouchNum; ++i)
        {
                
            var active = i < touches.Length;
            var touch = active ? touches[i] : new Touch();
            onTouches[i].Value = new TouchInfo(active, touch);
        }
    }
}