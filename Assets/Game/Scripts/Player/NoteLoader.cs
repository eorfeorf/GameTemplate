using System;
using System.Collections.Generic;
using Game.Scripts.Notes;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class NoteLoader : MonoBehaviour
    {
        [SerializeField] private NoteBase tapNotePrefab;
        [SerializeField] private NoteBase longNotePrefab;
        [SerializeField] private NoteBase flickNotePrefab;

        /// <summary>
        /// 譜面からノーツを生成.
        /// </summary>
        /// <param name="gameManager"></param>
        /// <param name="musicScoreData"></param>
        /// <returns></returns>
        public List<NoteBase> Load(GameManager.GameManager gameManager, MusicScore.MusicScoreData musicScoreData)
        {
            var notes = new List<NoteBase>();

            // MusicScoreを使って
            var note = Instantiate(GetNotePrefab((int)NoteType.Tap));
            note.Initialize(gameManager.GameContext, NoteType.Tap, new []{3.0f});
            
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
