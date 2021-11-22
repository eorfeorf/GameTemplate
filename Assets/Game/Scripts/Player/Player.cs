using UniRx;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class Player
    {
        public ReactiveProperty<Vector2Int> Pos { get; } = new ReactiveProperty<Vector2Int>();

        public IReadOnlyReactiveProperty<Vector2Int> StickInput => stickInput;
        private readonly ReactiveProperty<Vector2Int> stickInput = new ReactiveProperty<Vector2Int>();

        public void UpdatePosition(Vector2Int move)
        {
            stickInput.Value = new Vector2Int(
                Mathf.Clamp(Pos.Value.x + move.x, 0, GameInfo.GameInfo.Edge - 1),
                Mathf.Clamp(Pos.Value.y + move.y, 0, GameInfo.GameInfo.Edge - 1)
            );
        }
        
    }
}