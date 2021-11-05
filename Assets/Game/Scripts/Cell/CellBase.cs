using UnityEngine;

namespace Game.Scripts.Cell
{
    public class CellBase : ICell
    {
        public CellType Type { get; set; }
        public Vector2Int Pos { get; set; }

        public CellBase()
        {
            Type = CellType.None;
        }
        public CellBase(CellType type, Vector2Int pos)
        {
            Type = type;
            Pos = pos;
        }
        
        public virtual bool CheckCanMove()
        {
            return true;
        }
    }
}
