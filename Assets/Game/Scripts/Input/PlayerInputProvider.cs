using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerInputProvider : MonoBehaviour, IInputProvider
    {
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

        private void Start()
        {
            InputUpdate().Forget();
        }

        private UniTaskVoid InputUpdate()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                onPushedLeft.Value = Unit.Default;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                onPushedRight.Value = Unit.Default;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                onPushedUp.Value = Unit.Default;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                onPushedDown.Value = Unit.Default;
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                onPushedDecide.Value = Unit.Default;
            }
            
            return new UniTaskVoid();
        }
    }
}
