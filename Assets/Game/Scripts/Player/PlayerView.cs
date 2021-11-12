using System;
using Game.Scripts.Stage;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Transform spriteTransform;

        public ReactiveProperty<Vector2Int> Move = new ReactiveProperty<Vector2Int>();

        private PlayerPresenter presenter;

        public void Setup(StageSequencer stageSequencer)
        {
            presenter = new PlayerPresenter(this, stageSequencer);
        }

        public void ApplySpriteTransform(Vector2Int pos)
        {
            // 0~7 -> -4 ~ 4
            float x, y;
            x = pos.x - GameInfo.GameInfo.EdgeHalf;
            y = pos.y - GameInfo.GameInfo.EdgeHalf;
            x *= GameInfo.GameInfo.Size;
            y *= GameInfo.GameInfo.Size;
            x += GameInfo.GameInfo.SizeHalf;
            y += GameInfo.GameInfo.SizeHalf;
            spriteTransform.position = new Vector3(x, y, 0);
        }

        private void Update()
        {
            var move = GetInputMove();
            Move.Value = move;
        }

        private Vector2Int GetInputMove()
        {
            var ret = new Vector2Int();

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ret.x = -1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ret.x = 1;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                ret.y = 1;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                ret.y = -1;
            }

            return ret;
        }
    }
}