using System;
using Game.Scripts.Stage;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Transform spriteTransform;

        public IReadOnlyReactiveProperty<Vector2Int> Move => move;
        private readonly ReactiveProperty<Vector2Int> move = new ReactiveProperty<Vector2Int>();

        private bool left = false, right = false, up = false, down = false;

        public void Setup(StageSequencer stageSequencer, IInputEventProvider inputEventProvider)
        {
            new PlayerPresenter(this, stageSequencer);

            inputEventProvider.OnPushedLeft.Subscribe(_ =>
            {
                left = true;
            }).AddTo(this);
            inputEventProvider.OnPushedRight.Subscribe(_ =>
            {
                right = true;
            }).AddTo(this);
            inputEventProvider.OnPushedUp.Subscribe(_ =>
            {
                up = true;
            }).AddTo(this);
            inputEventProvider.OnPushedDown.Subscribe(_ =>
            {
                down = true;
            }).AddTo(this);
        }

        public void ApplySpriteTransform(Vector2Int pos)
        {
            // 0~7 -> -4 ~ 4
            float x, y;
            x = pos.x - GameInfo.GameInfo.EdgeHalf;
            y = pos.y - GameInfo.GameInfo.EdgeHalf;
            x *= GameInfo.GameInfo.Size;
            y *= GameInfo.GameInfo.Size;
            x += GameInfo.GameInfo.SizeHalf;
            y += GameInfo.GameInfo.SizeHalf;
            spriteTransform.position = new Vector3(x, y, 0);
        }

        private void Update()
        {
            if (left)
            {
                move.Value = new Vector2Int(-1, 0);
            }
            else if (right)
            {
                move.Value = new Vector2Int(1, 0);
            }
            else if (up)
            {
                move.Value = new Vector2Int(0, 1);
            }
            else if (down)
            {
                move.Value = new Vector2Int(0, -1);
            }
            
            right = left = up = down = false;
            move.Value = Vector2Int.zero;
        }
    }
}