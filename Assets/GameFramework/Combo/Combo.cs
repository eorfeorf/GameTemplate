using UniRx;

namespace GameFramework.Combo
{
    public class Combo
    {
        public IReactiveProperty<int> Count => count;
        private ReactiveProperty<int> count = new();

        public bool CanDraw() => count.Value >= 2;
        
        public void Add(int combo = 1)
        {
            this.count.Value += combo;
        }

        public void Reset()
        {
            this.count.Value = 0;
        }
    }
}
