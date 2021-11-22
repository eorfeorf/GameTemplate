using System.Collections.Generic;
using Game.Scripts.Notes;

public static class NotesLoader
{
    // IDからノーツを生成.
    public static List<NoteBase> Load(int musicScoreId)
    {
        var notes = new List<NoteBase>();
        
        notes.Add(new TapNote(NoteType.Tap, 1));
        notes.Add(new LongNote(NoteType.Long, 2));
        notes.Add(new FlickNote(NoteType.Flick, 3));

        return notes;
    }
}
