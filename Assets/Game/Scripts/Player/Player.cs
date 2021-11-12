using Game.Scripts.Stage;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class Player
    {
        public IReadOnlyReactiveProperty<Vector2Int> Pos => pos;
        
        private readonly ReactiveProperty<Vector2Int> pos = new ReactiveProperty<Vector2Int>();
        private readonly StageSequencer stageSequencer;

        public Player(StageSequencer stageSequencer)
        {
            this.stageSequencer = stageSequencer;
        }

        public void UpdatePosition(Vector2Int move)
        {
            var temp = new Vector2Int(
                Mathf.Clamp(pos.Value.x + move.x, 0, GameInfo.GameInfo.Edge - 1),
                Mathf.Clamp(pos.Value.y + move.y, 0, GameInfo.GameInfo.Edge - 1)
            );

            var canMove = stageSequencer.CanMoveToTargetPosition(temp);
            if (canMove)
            {
                pos.Value = temp;   
            }
        }
    }
}