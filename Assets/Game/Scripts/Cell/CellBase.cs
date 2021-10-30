using UnityEngine;

namespace Game.Scripts.Cell
{
    public abstract class CellBase : ICell
    {
        public CellType Type => type;
        protected CellType type;

        public abstract bool CheckCanMove();
    }
}
