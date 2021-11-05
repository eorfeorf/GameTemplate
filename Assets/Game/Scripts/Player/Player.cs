using Game.Scripts.Stage;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class Player
    {
        public IReadOnlyReactiveProperty<Vector2Int> Pos => pos;
        
        private ReactiveProperty<Vector2Int> pos;
        private StageSequencer stageSequencer;

        private void Update()
        {
            var move = GetInputMove();
            var temp = new Vector2Int(
                Mathf.Clamp(pos.Value.x + move.x, 0, GameInfo.GameInfo.Edge - 1),
                Mathf.Clamp(pos.Value.y + move.y, 0, GameInfo.GameInfo.Edge - 1)
            );

            var canMove = stageSequencer.CanMoveToTargetPosition(temp);
            if (canMove)
            {
                pos.Value = temp;   
            }
            //Debug.Log(pos);
        }

        private Vector2Int GetInputMove()
        {
            var ret = new Vector2Int();

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ret.x = -1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ret.x = 1;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                ret.y = 1;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                ret.y = -1;
            }

            return ret;
        }

        public void Setup(StageSequencer stageSequencer)
        {
            this.stageSequencer = stageSequencer;
        }
    }
}