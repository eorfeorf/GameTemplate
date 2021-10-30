using UnityEngine;

namespace Game.Scripts.Stage
{
    public class StageSequencer
    {
        private Stage stage = new Stage();

        public StageSequencer()
        {
            // 初回生成
        }

        public bool CanMoveToTargetPosition(Vector2Int targetPosition)
        {
            var cell = stage.GetCell(targetPosition);
            //return cell.CheckCanMove();
            return true;
        }
    }
}
