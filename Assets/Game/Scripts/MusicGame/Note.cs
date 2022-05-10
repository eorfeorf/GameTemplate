namespace Game.Scripts.MusicGame
{
    internal class Note
    {
        public float Time => time;
        public bool Active;
        public NotePointType PrevPoint => prevPoint;
        public NotePointType NextPoint => nextPoint;
        
        private float time;
        private NoteType type;
        private NotePointType prevPoint;
        private NotePointType nextPoint;
        private NoteView view;

        public Note(float time, NoteType type, NotePointType prevPoint, NotePointType nextPoint, NoteView view)
        {
            this.time = time;
            this.type = type;
            this.prevPoint = prevPoint;
            this.nextPoint = nextPoint;
            this.view = view;
            Active = true;
        }
    }
}