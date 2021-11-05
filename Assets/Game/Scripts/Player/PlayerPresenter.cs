using UniRx;

namespace Game.Scripts.Player
{
    public class PlayerPresenter
    {
        private readonly PlayerView view;
        private readonly CompositeDisposable disposable = new CompositeDisposable();
        
        public PlayerPresenter(PlayerView view)
        {
            this.view = view;
            var model = new Player();

            model.Pos.Subscribe(view.ApplySpriteTransform).AddTo(disposable);
        }

        ~PlayerPresenter()
        {
            disposable.Dispose();
        }
    }
}
