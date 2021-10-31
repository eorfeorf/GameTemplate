using System;
using Game.Scripts.Cell;

namespace Game.Scripts.Object
{
    public class Goal : CellBase, IOnPassed
    {
        public Action OnPassed => onPassed;
        private Action onPassed;

        public Goal()
        {
            onPassed += Passed;
        }

        ~Goal()
        {
            onPassed -= Passed;
        }
        
        public override bool CheckCanMove()
        {
            return true;
        }

        private void Passed()
        {
            
        }
    }
}
