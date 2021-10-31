using Game.Scripts.Stage;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Transform spriteTransform;

        private Vector2Int pos;
        private StageSequencer stageSequencer;

        private void Awake()
        {
        }

        private void Update()
        {
            var move = GetInputMove();
            var temp = new Vector2Int(
                Mathf.Clamp(pos.x + move.x, 0, GameInfo.GameInfo.Edge - 1),
                Mathf.Clamp(pos.y + move.y, 0, GameInfo.GameInfo.Edge - 1)
            );

            var canMove = stageSequencer.CanMoveToTargetPosition(temp);
            if (canMove)
            {
                pos = temp;   
            }
            //Debug.Log(pos);

            // view
            UpdateSpritePosition(pos);
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

        private void UpdateSpritePosition(Vector2Int pos)
        {
            // var x = pos.x - GameInfo.FieldHalf;
            // var y = pos.y - GameInfo.FieldHalf;
            // 0~7 -> -4 ~ 4
            float x, y;
            x = pos.x - GameInfo.GameInfo.EdgeHalf;
            y = pos.y - GameInfo.GameInfo.EdgeHalf;
            x = x * GameInfo.GameInfo.Size;
            y = y * GameInfo.GameInfo.Size;
            x += GameInfo.GameInfo.SizeHalf;
            y += GameInfo.GameInfo.SizeHalf;
            spriteTransform.position = new Vector3(x, y, 0);
        }

        public void Setup(StageSequencer stageSequencer)
        {
            this.stageSequencer = stageSequencer;
        }
    }
}