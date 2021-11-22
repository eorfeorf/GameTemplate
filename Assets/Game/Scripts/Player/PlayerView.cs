using UniRx;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Transform spriteTransform;

        public IReadOnlyReactiveProperty<Vector2Int> Move => move;
        private readonly ReactiveProperty<Vector2Int> move = new ReactiveProperty<Vector2Int>();

        public IReadOnlyReactiveProperty<Unit> Decide;
        public IReadOnlyReactiveProperty<Unit> Cancel;
        
        private bool left = false, right = false, up = false, down = false;

        public PlayerView Setup(IInputEventProvider inputEventProvider)
        {
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

            Decide = inputEventProvider.OnPushedDecide;
            Cancel = inputEventProvider.OnPushedCancel;

            return this;
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
            var temp = new Vector2Int();
            if (left)
            {
                temp += Vector2Int.left;
            }
            if (right)
            {
                temp += Vector2Int.right;
            }
            if (up)
            {
                temp += Vector2Int.up;
            }
            if (down)
            {
                temp += Vector2Int.down;
            }
            
            right = left = up = down = false;
            move.Value = temp;
        }
    }
}