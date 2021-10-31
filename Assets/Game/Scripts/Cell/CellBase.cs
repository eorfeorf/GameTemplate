using UnityEngine;

namespace Game.Scripts.Cell
{
    public class CellBase : ICell
    {
        public CellType Type { get; set; }

        public CellBase()
        {
            Type = CellType.None;
        }
        public CellBase(CellType type)
        {
            Type = type;
        }
        
        public virtual bool CheckCanMove()
        {
            return true;
        }
    }
}
