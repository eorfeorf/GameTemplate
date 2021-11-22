using UniRx;

namespace Game.Scripts.Player
{
    public class PlayerPresenter
    {
        private readonly PlayerView view;
        private readonly Player model;
        private readonly CompositeDisposable disposable;
        
        public PlayerPresenter(PlayerView view, Player model)
        {
            this.view = view;
            this.model = model;
            disposable = new CompositeDisposable();

            model.Pos.Subscribe(view.ApplySpriteTransform).AddTo(disposable);
            view.Move.Subscribe(model.UpdatePosition).AddTo(disposable);
        }

        ~PlayerPresenter()
        {
            disposable.Dispose();
        }
    }
}
