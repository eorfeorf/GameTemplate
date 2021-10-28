using System;
using GameFramework.Utilities;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Transform spriteTransform;

        private Vector2Int pos;

        private void Awake()
        {
        }

        private void Update()
        {
            var move = GetInputMove();
            pos.x = Mathf.Clamp(pos.x + move.x, 0, GameInfo.FieldNum - 1);
            pos.y = Mathf.Clamp(pos.y + move.y, 0, GameInfo.FieldNum - 1);
            //Debug.Log(pos);

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
            x = pos.x - GameInfo.FieldHalf;
            y = pos.y - GameInfo.FieldHalf;
            x = x * GameInfo.Size;
            y = y * GameInfo.Size;
            x += GameInfo.SizeHalf;
            y += GameInfo.SizeHalf;
            spriteTransform.position = new Vector3(x, y, 0);
        }
    }
}