using Game.Scripts.Stage;
using UniRx;

namespace Game.Scripts.Player
{
    public class PlayerPresenter
    {
        private readonly PlayerView view;
        private readonly Player model;
        private readonly CompositeDisposable disposable;
        
        public PlayerPresenter(PlayerView view, StageSequencer stageSequencer)
        {
            this.view = view;
            model = new Player(stageSequencer);
            disposable = new CompositeDisposable();

            model.Pos.Subscribe(view.ApplySpriteTransform).AddTo(disposable);
            view.Move.Subscribe(move => model.UpdatePosition(move)).AddTo(disposable);
        }

        ~PlayerPresenter()
        {
            disposable.Dispose();
        }
    }
}
