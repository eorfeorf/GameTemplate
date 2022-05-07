namespace Game.Scripts.MusicGame
{
    internal class Note
    {
        public float Time => time;
        public bool Active;
        
        private float time;
        private NoteType type;
        private NoteView view;

        public Note(float time, NoteType type, NoteView view)
        {
            this.time = time;
            this.type = type;
            this.view = view;
            Active = true;
        }
    }
}