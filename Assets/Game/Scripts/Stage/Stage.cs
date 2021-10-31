using Game.Scripts.Cell;
using UnityEngine;
using UnityEngine.Assertions;

namespace Game.Scripts.Stage
{
    /// <summary>
    /// ステージを定義.
    /// </summary>
    public class Stage
    {
        private ICell[] cells;

        public Stage()
        {
            cells = new ICell[GameInfo.GameInfo.Edge * GameInfo.GameInfo.Edge];

            // TODO:仮初期化.実際はStageGeneratorに任せる.
            for (int i = 0; i < cells.Length; ++i)
            {
                cells[i] = new CellBase(CellType.None);
            }
        }

        public ICell GetCell(Vector2Int position)
        {
            var index = position.y * GameInfo.GameInfo.Edge + position.x;
            Assert.IsTrue(0 <= index && index < GameInfo.GameInfo.CellNum);
            return cells[index];
        }

        public void SetCell(int index, ICell element)
        {
            Assert.IsTrue(0 <= index && index < GameInfo.GameInfo.CellNum);
            cells[index] = element;
        }
    }
}
