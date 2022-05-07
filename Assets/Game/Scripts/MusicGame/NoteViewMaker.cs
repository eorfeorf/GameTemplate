using System;
using UnityEngine;

namespace Game.Scripts.MusicGame
{
    public class NoteViewMaker : MonoBehaviour
    {
        [SerializeField] private NoteView noteViewPrefab;
        [SerializeField] private Sprite NormalNoteSprite;

        private Transform parent;
        
        public void SetParent(Transform transform)
        {
            parent = transform;
        }
        
        public NoteView CreateNote(NoteType type)
        {
            switch (type)
            {
                case NoteType.Normal:
                    var view = Instantiate(noteViewPrefab, parent);
                    view.SetSprite(NormalNoteSprite);
                    return view;
                case NoteType.Hold:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
