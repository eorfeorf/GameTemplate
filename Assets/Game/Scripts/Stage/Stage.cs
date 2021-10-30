using UnityEngine;

namespace Game.Scripts.Stage
{
    /// <summary>
    /// ステージを定義.
    /// </summary>
    public class Stage
    {
        private ICell[] cells = new ICell[GameInfo.GameInfo.FieldNum * GameInfo.GameInfo.FieldNum];

        public ICell GetCell(Vector2Int position)
        {
            return cells[position.y * GameInfo.GameInfo.FieldNum + position.x];
        }
    }
}
