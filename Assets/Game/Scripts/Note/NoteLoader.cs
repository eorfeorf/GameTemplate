using System;
using System.Collections.Generic;
using Game.Scripts.Notes;
using UnityEngine;

namespace Game.Scripts.Note
{
    public class NoteLoader : MonoBehaviour
    {
        [SerializeField] private NoteBase tapNotePrefab;
        [SerializeField] private NoteBase longNotePrefab;
        [SerializeField] private NoteBase flickNotePrefab;

        /// <summary>
        /// 譜面からノーツを生成.
        /// </summary>
        /// <param name="musicScore"></param>
        /// <returns></returns>
        public List<NoteBase> Load(MusicScore.MusicScore musicScore)
        {
            var notes = new List<NoteBase>();

            
            var note = Instantiate(GetNotePrefab((int)NoteType.Tap));
            notes.Add(note);
            // notes.Add(new TapNote(NoteType.Tap, 1));
            // //notes.Add(new LongNote(NoteType.Long, 2));
            // notes.Add(new FlickNote(NoteType.Flick, 3));

            return notes;
        }

        private NoteBase GetNotePrefab(NoteType type)
        {
            return type switch
            {
                NoteType.Tap => tapNotePrefab,
                NoteType.Long => longNotePrefab,
                NoteType.Flick => flickNotePrefab,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}
