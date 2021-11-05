using System;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Transform spriteTransform;
        [SerializeField] private IInputEventProvider inputEventProvider;

        private PlayerPresenter presenter;

        private void Start()
        {
            presenter = new PlayerPresenter(this);
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
    }
}
