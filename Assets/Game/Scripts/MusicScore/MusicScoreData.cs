using System.Collections.Generic;
using Game.Scripts.Notes;

namespace Game.Scripts.MusicScore
{
    /// <summary>
    /// プレイに必要なデータ.
    /// </summary>
    public class MusicScoreData
    {
        private List<NoteBase> notes;

        public MusicScoreData(global::MusicScore musicScore)
        {
            // IDとパスのDirectionaryがある？
            this.notes = NotesLoader.Load(musicScore.Id);
        }
    }
}
