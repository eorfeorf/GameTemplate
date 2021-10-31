using System;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerInputProvider : MonoBehaviour, IInputProvider
    {
        public IReadOnlyReactiveProperty<Unit> OnPushedLeft => onPushedLeft;
        private ReactiveProperty<Unit> onPushedLeft;
        public IReadOnlyReactiveProperty<Unit> OnPushedRight => onPushedRight;
        private ReactiveProperty<Unit> onPushedRight;
        public IReadOnlyReactiveProperty<Unit> OnPushedUp => onPushedUp;
        private ReactiveProperty<Unit> onPushedUp;
        public IReadOnlyReactiveProperty<Unit> OnPushedDown => onPushedDown;
        private ReactiveProperty<Unit> onPushedDown;
        public IReadOnlyReactiveProperty<Unit> OnPushedDecide => onPushedDecide;
        private ReactiveProperty<Unit> onPushedDecide;
        public IReadOnlyReactiveProperty<Unit> OnPushedCancel => onPushedCancel;
        private ReactiveProperty<Unit> onPushedCancel;

        private void Update()
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
        }
    }
}
