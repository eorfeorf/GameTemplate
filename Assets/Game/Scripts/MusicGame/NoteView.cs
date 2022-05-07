using System;
using UnityEngine;

namespace Game.Scripts.MusicGame
{
    /// <summary>
    /// ノーツを表示するクラス
    /// </summary>
    public class NoteView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        private Sprite sprite;

        public void SetSprite(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }
    }
}