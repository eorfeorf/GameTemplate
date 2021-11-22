using UniRx;
using UnityEngine;

namespace Game.Scripts.Stage
{
    public class StageSequencer
    {
        private Stage stage = new Stage();
        private Player.Player player;

        private CompositeDisposable disposable = new CompositeDisposable();

        public StageSequencer(Player.Player player)
        {
            // 初回生成
            
            // プレイヤーが移動したらシーケンス開始.
            this.player = player;
            player.StickInput.SkipLatestValueOnSubscribe().Subscribe(MovePlayer).AddTo(disposable);
        }

        ~StageSequencer()
        {
            disposable.Dispose();
        }

        private void MovePlayer(Vector2Int tempPos)
        {
            // プレイヤー移動.
            var canMove = CanMoveToTargetPosition(tempPos);
            if (canMove)
            {
                
            }
            else
            {
                
            }
        }
        
        private bool CanMoveToTargetPosition(Vector2Int targetPosition)
        {
            var cell = stage.GetCell(targetPosition);
            //return cell.CheckCanMove();
            return true;
        }

        private void MainSequence()
        {
            
        }
    }
}
