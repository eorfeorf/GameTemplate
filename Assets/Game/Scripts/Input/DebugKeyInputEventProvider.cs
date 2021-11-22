using System;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Input
{
    public sealed class DebugKeyInputEventProvider : MonoBehaviour, IInputEventProvider
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

        public IReadOnlyReactiveProperty<Touch[]> OnTouches => onTouches;
        private ReactiveProperty<Touch[]> onTouches = new ReactiveProperty<Touch[]>();

        private void Update()
        {
            onVertical.Value = UnityEngine.Input.GetAxis("Vertical");
            onHorizontal.Value = UnityEngine.Input.GetAxis("Horizontal");

            if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow))
            {
                onPushedLeft.SetValueAndForceNotify(Unit.Default);
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow))
            {
                onPushedRight.SetValueAndForceNotify(Unit.Default);
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.UpArrow))
            {
                onPushedUp.SetValueAndForceNotify(Unit.Default);
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.DownArrow))
            {
                onPushedDown.SetValueAndForceNotify(Unit.Default);
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.Z))
            {
                onPushedDecide.SetValueAndForceNotify(Unit.Default);
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.X))
            {
                onPushedCancel.SetValueAndForceNotify(Unit.Default);
            }
        }
    }
}